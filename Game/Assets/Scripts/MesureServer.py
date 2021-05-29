import time
import grovepi
import numpy as np
import socket
import struct
import traceback
import logging
import threading
import random

sensorPin = 3 #D3 port for heartrate
sensor = 0 #A0 port for skin conductence

values = [] #Contains each battement par second
values2 = [] # resistance by secon
heartrates = [] #Contains heartrate estimation
resistances = [] #Contain each resistance estimation
scores = [] 
mappedScore = 0 # the send data between 0 and 1, 0-> stress/highHR+lowResistance, 1-> no stress/lowHR+HighResistance
def computeMeasure():
    global values,values2,heartrates,resistances,scores,output,mappedScore
    print("Estimating the heart rate and resistance, wait 10 seconds...")
    while True:
        heart_value = grovepi.read_interrupt_state(sensorPin) #Battement par seconde
        print("earclip value test: ",heart_value)
        sensor_value = grovepi.analogRead(sensor) #Resistance
        print("resistance value test: ",sensor_value)
        time.sleep(1)
        values2.append(sensor_value)
        values.append(heart_value)

        if len(values2)>5: #take only the resistance over the 5 last seconds
            values2 = values2[len(values2)-5:-1]

        if len(values)>10:
            values = values[len(values)-10:-1] 
            print("length of heart values: ",len(values))
            print("lenght of resistance values: ",len(values2))
            HR = np.mean(values) * 60
            resistance = np.mean(values2)
            
            
            resistances.append(resistance)
            heartrates.append(HR)
            min1 = np.min(heartrates)
            max1 = np.max(heartrates)
            min2 = np.min(resistances)
            max2 = np.max(resistances)
            
            score = HR*(1/resistance)#The more user is stressed the more the score is big
            scores.append(score)
            min3 = np.min(scores)
            max3 = np.max(scores)
            
            # We will do a mapping to 0 and 1
            mappedScore = 1-(1/(max3-min3) * (score - min3))# the more this valus is big the more the user isn't stressful
            
            
            print("Min value of heart: ",min1)
            print("Max value of heart: ",max1)
            print("Min value of resistance : ",min2)
            print("Max value of resistance : ",max2)
            print("Min value of score : ",min3)
            print("Max value of score : ",max3)
            print("Estimated HR = ",HR)
            print("Estimated Resistance =",resistance)
            print("Mapped Score: ",mappedScore)
            
            
            
        
            

    
def sending():
    global resistances,heartrates,mappedScore
    s = socket.socket()
    #s = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    socket.setdefaulttimeout(None)
    print('socket created ')
    port = 60000
    s.bind(('192.168.1.2', port)) #local host
    s.listen(30) #specifies the number of unaccepted connections that the system will allow before refusing new connections
    print('socket listensing ... ')
    while True:
        try:
            c, addr = s.accept() #when port connected
            #bytes_received = c.recv(4000) #received bytes
            #array_received = np.frombuffer(bytes_received, dtype=np.float32) #converting into float array

            #data to send
            output = np.asarray([mappedScore,heartrates[-1],resistances[-1]])
            #output = np.asarray([float(random.randint(1,10)) for i in range(5)])
            print("Send data:",output)
            bytes_to_send = struct.pack('%sf' % len(output), *output)

            # #data to send
            # nn_output = return_prediction(array_received) #NN prediction (e.g. model.predict())
            # bytes_to_send = struct.pack('%sf' % len(nn_output), *nn_output) #converting float to byte


            c.sendall(bytes_to_send) #sending back
            c.close()
        except Exception as e:
            logging.error(traceback.format_exc())
            print("error")
            c.sendall(bytearray([]))
            c.close()
            break

#sending()
#computeMeasure()
# Initialize threat for the server and the other for taking the mesurement
# When a server request come we send the global variable modified by the other thread

t1 = threading.Thread(target=sending)
t2 = threading.Thread(target=computeMeasure)

t1.start()
t2.start()
