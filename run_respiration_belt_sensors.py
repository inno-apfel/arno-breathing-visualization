import time
from Server import Client
import ctypes
from gdx import gdx

myClient1 = Client(address="localhost", port=2500, autoReconnect=False, byteOrder="little")
print('Client Created')

gdx = gdx.gdx()
gdx.open_usb()
gdx.select_sensors()
gdx.start()

def lerp(a, b, percent):
    if b > a:
        return a + (b-a)*percent
    else:
        return a - (a-b)*percent

def on_server_connected(server):
    print('connected')

    lerp_rate = 0.5
    previous_scalar = 0
    received_scalar = 0
    counter = 0

    # run for 10 sec
    while counter < 300:
        measurements = gdx.read()

        previous_scalar = received_scalar
        received_scalar = 80 *(1/50)*float(str(measurements)[1:-1])

        percent_complete = 0
        while percent_complete < 1:
            # 0.05 = 1/recording_per_sec, def=20
            time.sleep(0.05*lerp_rate)
            percent_complete += lerp_rate
            scalar = str(lerp(previous_scalar, received_scalar, percent_complete))
            myClient1.send(scalar)
            print('Scalar: ' + str(scalar))
        counter += 1

    gdx.stop()
    gdx.close()
    myClient1.close()
    print('Client Closed')

myClient1.add_onconnect_callback(on_server_connected)

myClient1.connect()
print('Client Connected')
