using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;

public class CameraControl : MonoBehaviour
{

    public string ip = "127.0.0.1";
    public int port = 60000;
    public Socket client;
    [SerializeField]
    public float[] dataIn;

    public Transform target;
    public Transform bg1;
    public Transform bg2;
    public Transform ligneInvisible,firstText,secondText; //firstText is the equation text

    private float size;

    // difficult and scrolling speed should be defined here
    private int compt,textCompt; //compt is used to change button value depending of the equation of the current bg, textCompt is to know when to check button value
    EquationControl equationControl;
    BouttonsControl bouttonsControl;

    // difficulty in [1,10]
    private int difficulty;
    //

    // Start is called before the first frame update
    void Start()
    {

        difficulty = 5;
        size = bg1.GetComponent<BoxCollider2D>().size.y;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Camera
        Vector3 targetpos = new Vector3(target.position.x,target.position.y,transform.position.z);
        transform.position = targetpos;

        // Background

        if (transform.position.y >= bg2.position.y) {
            bg1.position = new Vector3(bg1.position.x, bg2.position.y + size, bg1.position.z);

            equationControl = GameObject.FindGameObjectWithTag("equations").GetComponent<EquationControl>();
            equationControl.UpdateEquation(compt,difficulty);

            bouttonsControl = GameObject.FindGameObjectWithTag("buttons").GetComponent<BouttonsControl>();

            if (compt % 2 == 0)
            {
                bouttonsControl.ChangeBoutonsValueSecondBg();
            }
            else
            {
                bouttonsControl.ChangeBoutonsValueFirstBg();
            }

            compt++;
            SwitchBac();
            dataIn = ServerRequest();
            foreach (var item in dataIn)
            {
                Debug.Log(item.ToString());
            }
        }

        if ((ligneInvisible.position.y >= firstText.position.y) && (textCompt % 2 == 0))
        {
            bouttonsControl = GameObject.FindGameObjectWithTag("buttons").GetComponent<BouttonsControl>();
            bouttonsControl.CheckButtonValueFirstBg();
            textCompt++;

        }

        if ((ligneInvisible.position.y >= secondText.position.y) && (textCompt % 2 == 1))
        {
            bouttonsControl = GameObject.FindGameObjectWithTag("buttons").GetComponent<BouttonsControl>();
            bouttonsControl.CheckButtonValueSecondBg();
            textCompt++;

        }
    }

    private void SwitchBac()
    {
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;



    }

    public float[] ServerRequest()
    {
        Debug.Log("serveur request");
        //print("request");
        //this.dataOut = dataOut; //debugging
        this.dataIn = Receive(); //debugging
        return this.dataIn;
    }

    /// <summary> 
    /// Send data to port, receive data from port.
    /// </summary>
    /// <param name="dataOut">Data to send</param>
    /// <returns></returns>
    public float[] Receive()
    {
        //initialize socket
        float[] floatsReceived;
        client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        client.Connect(ip, port);
        if (!client.Connected)
        {
            Debug.LogError("Connection Failed");
            return null;
        }

        //convert floats to bytes, send to port
        // var byteArray = new byte[dataOut.Length * 4];
        //Buffer.BlockCopy(dataOut, 0, byteArray, 0, byteArray.Length);
        //client.Send(byteArray);

        //allocate and receive bytes
        byte[] bytes = new byte[4000];
        int idxUsedBytes = client.Receive(bytes);
        //print(idxUsedBytes + " new bytes received.");

        //convert bytes to floats
        floatsReceived = new float[idxUsedBytes / 4];
        Buffer.BlockCopy(bytes, 0, floatsReceived, 0, idxUsedBytes);

        client.Close();
        return floatsReceived;
    }
}
