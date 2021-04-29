using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour
{

    public Transform target;
    public Transform bg1;
    public Transform bg2;

    private float size;

    private int compt;
    EquationControl equationControl;
    BouttonsControl bouttonsControl;
    //EquationControl equationControl = new EquationControl();
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
            ScoreScript.scorevalue += 10;

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

    }

    private void SwitchBac()
    {
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;



    }
}
