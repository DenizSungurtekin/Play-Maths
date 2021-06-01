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

    private float size,data,constante;
    public string operation1;
    public string operation2;

    // difficult and scrolling speed should be defined here
    private int compt,textCompt; //compt is used to change button value depending of the equation of the current bg, textCompt is to know when to check button value
    EquationControl equationControl;
    BouttonsControl bouttonsControl;
    Player player;

    // difficulty in [1,10]
    private float difficulty;
    //

    // Start is called before the first frame update
    void Start()
    {
        difficulty = (float)1.0;
        player = GameObject.FindGameObjectWithTag("verticalmvt").GetComponent<Player>();
        player.ms = (float)(1.0 + (2.0 / 9.0) * (difficulty - 1.0));
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

            data = (float)0.1; // Value in case there is no server request

            // UNCOMMENT IF THERE IS Connexion to server, dataIn = [mappedScore, Heartrates, ECD variations]
            /*dataIn = ServerRequest();  
            data = dataIn[0]; */

            Debug.Log("Received data: "+ data);

            updateDifficulty(data);
            updateGame(difficulty);

            compt++;
            SwitchBac();
        }

        if ((ligneInvisible.position.y >= firstText.position.y) && (textCompt % 2 == 0))
        {
            bouttonsControl = GameObject.FindGameObjectWithTag("buttons").GetComponent<BouttonsControl>();
            bouttonsControl.CheckButtonValueFirstBg(difficulty);
            textCompt++;
        }

        if ((ligneInvisible.position.y >= secondText.position.y) && (textCompt % 2 == 1))
        {
            bouttonsControl = GameObject.FindGameObjectWithTag("buttons").GetComponent<BouttonsControl>();
            bouttonsControl.CheckButtonValueSecondBg(difficulty);
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
        //Debug.Log("serveur request");
        this.dataIn = Receive();
        return this.dataIn;
    }
    public float[] Receive()
    {
        //Initialize socket
        float[] floatsReceived;
        client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        client.Connect(ip, port);
        if (!client.Connected)
        {
            Debug.LogError("Connection Failed");
            return null;
        }

        //allocate and receive bytes
        byte[] bytes = new byte[4000];
        int idxUsedBytes = client.Receive(bytes);

        //convert bytes to floats
        floatsReceived = new float[idxUsedBytes / 4];
        Buffer.BlockCopy(bytes, 0, floatsReceived, 0, idxUsedBytes);

        client.Close();
        return floatsReceived;
    }

    public void updateGame(float difficulty)
    {
        equationControl = GameObject.FindGameObjectWithTag("equations").GetComponent<EquationControl>();
        player = GameObject.FindGameObjectWithTag("verticalmvt").GetComponent<Player>();
        equationControl.UpdateEquation(compt,difficulty);
        player.ms = (float)(1.0 + (2.0 / 9.0) * (difficulty - 1.0));
        Debug.Log("MS: "+ player.ms);
        Debug.Log("Difficulty: " + difficulty);
    }

    public void updateDifficulty(float received)
    {
        constante = (float)0.2;
        difficulty = difficulty + received;
        difficulty = difficulty + constante;
        if (difficulty > 10)
        {
            difficulty = 10;
        }
    }
}
