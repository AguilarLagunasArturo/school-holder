""" Flowmeter graph with matplotlib """
import matplotlib.pyplot as plt
import matplotlib.animation as animation
import numpy as np
import serial
port = serial.Serial("/dev/ttyACM0")
port.flushInput()

""" Variables """
x_range = 60
plt_count = 0
total_sensors = 2
figure = plt.figure()
axis_1 = plt.subplot2grid((3, 3), (0, 0), rowspan=1, colspan=3, fig=figure)
# axis_1 = plt.subplot2grid((7, 1), (0, 0), rowspan=3, colspan=1, fig=figure)
#plt.title("Gasto")
#plt.xlabel("Segundos")
#plt.ylabel("L/min")
axis_2 = plt.subplot2grid((3, 3), (1, 0), rowspan=1, colspan=1, fig=figure)
# axis_2 = plt.subplot2grid((7, 1), (4, 0), rowspan=3, colspan=1, fig=figure)
#plt.xlabel("Segundos")
#plt.ylabel("L/min")
axis_3 = plt.subplot2grid((3, 3), (1, 1), rowspan=1, colspan=1, fig=figure)
axis_4 = plt.subplot2grid((3, 3), (1, 2), rowspan=1, colspan=1, fig=figure)
axis_5 = plt.subplot2grid((3, 3), (2, 0), rowspan=1, colspan=1, fig=figure)
axis_6 = plt.subplot2grid((3, 3), (2, 1), rowspan=1, colspan=1, fig=figure)
axis_7 = plt.subplot2grid((3, 3), (2, 2), rowspan=1, colspan=1, fig=figure)

time = [[], [], [], [], [], [], []]
flow = [[], [], [], [], [], [], []]

def animate(i):
    for val in range(8):
        getSerialData()
    axis_1.clear()
    axis_2.clear()
    axis_3.clear()
    axis_4.clear()
    axis_5.clear()
    axis_6.clear()
    axis_7.clear()

    axis_1.plot(time[0], flow[0], label="Seccion 1")
    axis_2.plot(time[1], flow[1], label="Seccion 2")
    axis_3.plot(time[2], flow[2], label="Seccion 3")
    axis_4.plot(time[3], flow[3], label="Seccion 4")
    axis_5.plot(time[4], flow[4], label="Seccion 5")
    axis_6.plot(time[5], flow[5], label="Seccion 6")
    axis_7.plot(time[6], flow[6], label="Seccion 7")

    axis_1.set_title("Gasto en tuberias")
    axis_2.set_ylabel('Gasto en L/min')
    axis_1.grid(True)
    axis_2.grid(True)
    axis_3.grid(True)
    axis_4.grid(True)
    axis_5.grid(True)
    axis_6.grid(True)
    axis_7.grid(True)

    #axis_1.legend(loc='upper left')

def getSerialData():
    port_bytes = port.readline()
    decoded_bytes = str(port_bytes[0:len(port_bytes)-2].decode("utf-8")).split(",")
    if (decoded_bytes[0] == "#"):
        decoded_bytes.pop(0)
        print(decoded_bytes)
        data = [float(i) for i in decoded_bytes]
        # Empezar en 1 porque '#' esta en pos '0'
        flow[0].append(data[0])
        flow[1].append(data[1])
        flow[2].append(data[2])
        flow[3].append(data[3])
        flow[4].append(data[4])
        flow[5].append(data[5])
        flow[6].append(data[6])
        global plt_count
        time[0].append(plt_count)
        time[1].append(plt_count)
        time[2].append(plt_count)
        time[3].append(plt_count)
        time[4].append(plt_count)
        time[5].append(plt_count)
        time[6].append(plt_count)
        plt_count += 1
        #print(plt_count)
        #print(flow)

ani = animation.FuncAnimation(figure, animate, interval=500)
plt.show()
