import matplotlib.pyplot as plt
import re
import glob

def plotFromCsv(name):
    parties = []
    print("Plotting file: ",name)
    with open(name, newline='') as csvfile:
        age = name[-6:-4]
        age = "Age: " + age

        if name[8]=='b':
            age = age + ", With Makey Makey"
        else:
            age = age + ", Without Makey Makey"

        partie = {}
        partie["MappedScore"] = []
        partie["HeartRate"] = []
        partie["EDA"] = []
        partie["Score"] = []
        i = 0

        for row in csvfile:
            if i == 0:
                i = i+1
                continue

            fields = re.split('[,*]', row)

            if fields[1] == "Delimiter": #New party
                parties.append(partie)

                partie = {}
                partie["MappedScore"] = []
                partie["HeartRate"] = []
                partie["EDA"] = []
                partie["Score"] = []
            else:
                partie["MappedScore"].append(float(fields[1]))
                partie["HeartRate"].append(float(fields[2]))
                partie["EDA"].append(float(fields[-2]))
                partie["Score"].append(float(fields[-1]))

    if len(parties)>4:
        parties = parties[0:4]


    y_1 = parties[0]["MappedScore"]
    y_2 = parties[1]["MappedScore"]
    y_3 = parties[2]["MappedScore"]
    y_4 = parties[3]["MappedScore"]

    x1 = [i for i in range(len(y_1))]
    x2 = [i for i in range(len(y_2))]
    x3 = [i for i in range(len(y_3))]
    x4 = [i for i in range(len(y_4))]

    fig, axs = plt.subplots(4, 1, sharex=True)
    fig.subplots_adjust(hspace=0.5)

    axs[0].plot(x1, y_1,'b')
    axs[0].set_title('Partie 1')
    axs[0].set_ylabel('Mapped Score')
    axs[0].set_xlabel('Time')

    axs[1].plot(x2, y_2,'r')
    axs[1].set_title('Partie 2')
    axs[1].set_ylabel('Mapped Score')
    axs[1].set_xlabel('Time')

    axs[2].plot(x3, y_3,'g')
    axs[2].set_title('Partie 3')
    axs[2].set_ylabel('Mapped Score')
    axs[2].set_xlabel('Time')

    axs[3].plot(x4, y_4,'m')
    axs[3].set_title('Partie 4')
    axs[3].set_ylabel('Mapped Score')
    axs[3].set_xlabel('Time')

    plt.suptitle("Send values, " + age, fontsize=15)
    plt.show()



    y_1 = parties[0]["HeartRate"]
    y_2 = parties[1]["HeartRate"]
    y_3 = parties[2]["HeartRate"]
    y_4 = parties[3]["HeartRate"]

    x1 = [i for i in range(len(y_1))]
    x2 = [i for i in range(len(y_2))]
    x3 = [i for i in range(len(y_3))]
    x4 = [i for i in range(len(y_4))]

    fig, axs = plt.subplots(4, 1, sharex=True)
    fig.subplots_adjust(hspace=0.5)

    axs[0].plot(x1, y_1,'b')
    axs[0].set_title('Partie 1')
    axs[0].set_ylabel("HeartRate")
    axs[0].set_xlabel('Time')

    axs[1].plot(x2, y_2,'r')
    axs[1].set_title('Partie 2')
    axs[1].set_ylabel("HeartRate")
    axs[1].set_xlabel('Time')

    axs[2].plot(x3, y_3,'g')
    axs[2].set_title('Partie 3')
    axs[2].set_ylabel("HeartRate")
    axs[2].set_xlabel('Time')

    axs[3].plot(x4, y_4,'m')
    axs[3].set_title('Partie 4')
    axs[3].set_ylabel("HeartRate")
    axs[3].set_xlabel('Time')

    plt.suptitle("Heartrates, " + age, fontsize=15)
    plt.show()


    y_1 = parties[0]["EDA"]
    y_2 = parties[1]["EDA"]
    y_3 = parties[2]["EDA"]
    y_4 = parties[3]["EDA"]

    x1 = [i for i in range(len(y_1))]
    x2 = [i for i in range(len(y_2))]
    x3 = [i for i in range(len(y_3))]
    x4 = [i for i in range(len(y_4))]

    fig, axs = plt.subplots(4, 1, sharex=True)
    fig.subplots_adjust(hspace=0.5)

    axs[0].plot(x1, y_1,'b')
    axs[0].set_title('Partie 1')
    axs[0].set_ylabel('EDA')
    axs[0].set_xlabel('Time')

    axs[1].plot(x2, y_2,'r')
    axs[1].set_title('Partie 2')
    axs[1].set_ylabel('EDA')
    axs[1].set_xlabel('Time')

    axs[2].plot(x3, y_3,'g')
    axs[2].set_title('Partie 3')
    axs[2].set_ylabel('EDA')
    axs[2].set_xlabel('Time')

    axs[3].plot(x4, y_4,'m')
    axs[3].set_title('Partie 4')
    axs[3].set_ylabel('EDA')
    axs[3].set_xlabel('Time')

    plt.suptitle("EDA, " + age, fontsize=15)
    plt.show()



    y_1 = parties[0]["Score"]
    y_2 = parties[1]["Score"]
    y_3 = parties[2]["Score"]
    y_4 = parties[3]["Score"]

    x1 = [i for i in range(len(y_1))]
    x2 = [i for i in range(len(y_2))]
    x3 = [i for i in range(len(y_3))]
    x4 = [i for i in range(len(y_4))]


    fig, axs = plt.subplots(4, 1, sharex=True)
    fig.subplots_adjust(hspace=0.5)

    axs[0].plot(x1, y_1,'b')
    axs[0].set_title('Partie 1')
    axs[0].set_ylabel('Score')
    axs[0].set_xlabel('Time')

    axs[1].plot(x2, y_2,'r')
    axs[1].set_title('Partie 2')
    axs[1].set_ylabel('Score')
    axs[1].set_xlabel('Time')

    axs[2].plot(x3, y_3,'g')
    axs[2].set_title('Partie 3')
    axs[2].set_ylabel('Score')
    axs[2].set_xlabel('Time')

    axs[3].plot(x4, y_4,'m')
    axs[3].set_title('Partie 4')
    axs[3].set_ylabel('Score')
    axs[3].set_xlabel('Time')

    plt.suptitle("Score, " + age, fontsize=15)
    plt.show()


# Plot of all the csv file

folderName = "Data"
path = folderName+"/*.csv"
filesNames=glob.glob(path)
print(filesNames)
for file in filesNames:
    plotFromCsv(file)