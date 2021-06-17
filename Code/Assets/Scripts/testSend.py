import socket
import struct
import traceback
import logging
import time
import numpy as np
import random

def sending():
    s = socket.socket()
    socket.setdefaulttimeout(None)
    print('socket created ')
    port = 60000
    s.bind(('127.0.0.1', port)) #local host
    s.listen(30) #specifies the number of unaccepted connections that the system will allow before refusing new connections
    print('socket listensing ... ')
    while True:
        try:
            c, addr = s.accept() #when port connected
            #bytes_received = c.recv(4000) #received bytes
            #array_received = np.frombuffer(bytes_received, dtype=np.float32) #converting into float array

            #data to send
            output = np.asarray([float(random.randint(1,10)) for i in range(5)])
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

sending()