using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationControl : MonoBehaviour
{

    public TextMesh eq1;
    public TextMesh eq2;

    public float a,b,c,d;
    public int low,high;
    // Start is called before the first frame update

    BouttonsControl bouttonsControl;
    void Start()
    {
        eq1 = GameObject.Find("bg_1_text").GetComponent<TextMesh>();
        eq2 =  GameObject.Find("bg_2_text").GetComponent<TextMesh>();


        a = Random.Range(1,10);
        b = Random.Range(1,10);

        c = Random.Range(1,10);
        d = Random.Range(1,10);

        // Change also buttons
        bouttonsControl = GameObject.FindGameObjectWithTag("buttons").GetComponent<BouttonsControl>();
        bouttonsControl.ChangeBoutonsValueFirstBg();
    }

    // Update is called once per frame
    void Update()
    {
         eq1.text =  a.ToString() + " + " + b.ToString() + " = ?";
         eq2.text =  c.ToString() + " + " + d.ToString() + " = ?";
    }

    // Update equation here : parameters : compt, difficulty
    public void UpdateEquation(int compt,int difficulty){

        low = (difficulty - 1) * 10;
        high = difficulty * 10;

        // need to update range here, depending on the difficulty
        // range increasing with the difficulty
        if (compt % 2 == 0)
        {
            a = Random.Range(low, high);
            b = Random.Range(low, high);
        }
        else
        {
            c = Random.Range(low, high);
            d = Random.Range(low, high);
        }


    }

}
