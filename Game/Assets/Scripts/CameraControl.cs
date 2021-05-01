using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour
{

    public Transform target;
    public Transform bg1;
    public Transform bg2;
    public Transform ligneInvisible,firstText,secondText; //firstText is the equation text

    private float size;

    private int compt,textCompt; //compt is used to change button value depending of the equation of the current bg, textCompt is to know when to check button value
    EquationControl equationControl;
    BouttonsControl bouttonsControl;
   

    // Start is called before the first frame update
    void Start()
    {

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
            equationControl.UpdateEquation(compt);

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
}
