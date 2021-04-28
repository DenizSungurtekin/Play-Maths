using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationControl : MonoBehaviour
{

    public TextMesh eq1;
    public TextMesh eq2;

    public static float a,b,c,d;
    // Start is called before the first frame update
    void Start()
    {
        eq1 = GameObject.Find("bg_1_text").GetComponent<TextMesh>();
        eq2 =  GameObject.Find("bg_2_text").GetComponent<TextMesh>();

        
        a = Random.Range(1,10);
        b = Random.Range(1,10);

        c = Random.Range(1,10);
        d = Random.Range(1,10);
    }

    // Update is called once per frame
    void Update()
    {
         eq1.text =  a.ToString() + " + " + b.ToString() + " = ?";
         eq2.text =  c.ToString() + " + " + d.ToString() + " = ?";
    }

    public void UpdateEquation(){

        // a = Random.Range(1,10);
        // b = Random.Range(1,10);
        //
        // c = Random.Range(1,10);
        // d = Random.Range(1,10);
        //
        // eq1.text =  a.ToString() + " + " + b.ToString() + " = ?";
        // eq2.text =  c.ToString() + " + " + d.ToString() + " = ?";


    }

}
