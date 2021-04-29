using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationControl : MonoBehaviour
{

    public TextMesh eq1;
    public TextMesh eq2;

    public float a,b,c,d;
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

    public void UpdateEquation(int compt){

        if (compt % 2 == 0)
        {
            a = Random.Range(1, 10);
            b = Random.Range(1, 10);
        }
        else
        {
            c = Random.Range(1, 10);
            d = Random.Range(1, 10);
        }


    }

}
