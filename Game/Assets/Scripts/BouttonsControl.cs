using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouttonsControl : MonoBehaviour
{

    public float answer,one;
    public int position_answer;
    public EquationControl equationControl;




    // Start is called before the first frame update
    void Start()
    {
  
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBoutonsValueFirstBg()
    {

        GameObject[] btn = GameObject.FindGameObjectsWithTag("buttons");

        position_answer = Random.Range(0, 3);
        equationControl = GameObject.FindGameObjectWithTag("equations").GetComponent<EquationControl>();
        answer = equationControl.a + equationControl.b;


         for (int i = 0; i < btn.Length; i++)
            {
                if (i == position_answer)
                {
                    //we check for location value and the assign it to the corresponding ans button 
                    btn[i].GetComponentInChildren<Text>().text = "" + answer;

                }
                else
                {
                    //for other ans button we assign random values
                    one = Random.Range(1, 20);
                    btn[i].GetComponentInChildren<Text>().text = "" + one;
                    

                    while (btn[i].GetComponentInChildren<Text>().text == "" + answer)
                    {
                        //we make sure that only one button has answer values 
                        btn[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 20);
                    }

                if (i > 0)
                {
                    while (btn[i - 1].GetComponentInChildren<Text>().text == "" + one)
                    {
                        //we make sure that the previous value is not the same
                        one = Random.Range(1, 20);
                        btn[i].GetComponentInChildren<Text>().text = "" + one;
                    }
                }

                    
                }

            }



     





    }

    public void ChangeBoutonsValueSecondBg()
    {

        GameObject[] btn = GameObject.FindGameObjectsWithTag("buttons");

        position_answer = Random.Range(0, 3);
        equationControl = GameObject.FindGameObjectWithTag("equations").GetComponent<EquationControl>();
        answer = equationControl.c + equationControl.d;


        for (int i = 0; i < btn.Length; i++)
        {
            if (i == position_answer)
            {
                //we check for location value and the assign it to the corresponding ans button 
                btn[i].GetComponentInChildren<Text>().text = "" + answer;

            }
            else
            {
                //for other ans button we assign random values
                one = Random.Range(1, 20);
                btn[i].GetComponentInChildren<Text>().text = "" + one;


                while (btn[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    //we make sure that only one button has answer values 
                    btn[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 20);
                }

                if (i > 0)
                {
                    while (btn[i - 1].GetComponentInChildren<Text>().text == "" + one)
                    {
                        //we make sure that the previous value is not the same
                        one = Random.Range(1, 20);
                        btn[i].GetComponentInChildren<Text>().text = "" + one;
                    }
                }


            }

        }









    }
}
