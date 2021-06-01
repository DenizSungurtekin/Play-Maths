import numpy as np
import socket
import struct
import traceback
import logging
import threading
import bitalino
import numpy
from biosppy.signals.ecg import hamilton_segmenter


#Globals, sended to unity
heartrates = []
variations = []
scores = []
mappedScore = 0

def computeMeasure():
    macAddress = "20:18:06:13:02:53"
    print("Searching for bitalino...")
    device = bitalino.BITalino(macAddress)
    print("Connection to bitalino done")

    global heartrates,variations,scores,mappedScore
    srate = 1000 #SamplingRate nbr de sample par seconde pour rendre discret
    nframes = 1000 #number of samples to acquire
    device.start(srate, [0,1]) #analogChannels - 0 ECG , -1 EDA
    values = []
    print("Collecting data...")
    try:
        while True:
            heartrateHistoryLen = 5 #Number of precedent hearrate computation taked into account
            interval = 3 # we count the number of hearbeat by peak detection in ECG each interval second
            multiplyer = 60/interval #Adapt the multiplayer depending of the interval
            data = device.read(nframes)

            ECGs = data[:,-2]

            for i in range(interval-1): # add ecg signals each second depending of the inteval
                int = device.read(nframes)
                ECGs = np.append(ECGs,int[:,-2])

            rpeaks = hamilton_segmenter(ECGs,sampling_rate = 1000)
            values = np.append(values,len(rpeaks[0])*multiplyer) #
            if len(values)>=heartrateHistoryLen:
                values = values[1:-1]

            heartrate = np.mean(values)
            heartrates.append(heartrate)


            EDA = data[:,-1]
            EDA_var = numpy.mean(abs(numpy.diff(EDA)))
            variations.append(EDA_var)


            score = heartrate * (EDA_var+0.5)  # The more user is stressed the more the score is big, + 0.5 to reduce the impact of the variation (very near to 0) on the score
            scores.append(score)
            min3 = np.min(scores)
            max3 = np.max(scores)
            mappedScore = 0.3 - (0.3 / (max3 - min3) * (score - min3))  # the more this valus is big the more the user isn't stressful first value is Nan because min = max, (between 0 and 0.3)
            print("Heartrate: ",heartrate)
            print("EDA variation: ",EDA_var)
            print("Send score: ",mappedScore)
            print(" --------- ")

    finally:
        device.trigger([0, 0])
        device.stop()
        device.close()


def sending():
    global resistances, heartrates, mappedScore
    s = socket.socket()
    socket.setdefaulttimeout(None)
    print('Socket Created ')
    port = 60000
    s.bind(('127.0.0.1', port))  # local host
    s.listen(30)  # specifies the number of unaccepted connections that the system will allow before refusing new connections
    print('Socket listensing ... ')
    while True:
        try:
            c, addr = s.accept()  # when port connected

            # data to send
            output = np.asarray([mappedScore, heartrates[-1], variations[-1]])
            print("Send data:", output)
            bytes_to_send = struct.pack('%sf' % len(output), *output)

            c.sendall(bytes_to_send)  # sending
            c.close()

        except Exception as e:
            logging.error(traceback.format_exc())
            print("error")
            c.sendall(bytearray([]))
            c.close()
            break

# # When a server request come we send the global variable modified by the other thread
t1 = threading.Thread(target=sending)
t2 = threading.Thread(target=computeMeasure)

t1.start()
t2.start()
