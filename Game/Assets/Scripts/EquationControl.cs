using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationControl : MonoBehaviour
{
    public string[] operations = {" + ", " - "};
    public TextMesh eq1;
    public TextMesh eq2;
    public string[] chosenOperations;
    public int randomIndex;
    public string op1, op2,op3,op4;
    public int a,b,c,d,a2,c2;
    public int low,high, answer2,answer1, answer;

    BouttonsControl bouttonsControl;

    void Start()
    {
        eq1 = GameObject.Find("bg_1_text").GetComponent<TextMesh>();
        eq2 =  GameObject.Find("bg_2_text").GetComponent<TextMesh>();

        a = Random.Range(1,10);
        b = Random.Range(1,10);
        c = Random.Range(1,10);
        d = Random.Range(1,10);

        randomIndex = Random.Range(0, 2);
        op1 = operations[randomIndex];
        randomIndex = Random.Range(0, 2);
        op2 = operations[randomIndex];

        eq1.text = a.ToString() + op1 + b.ToString() + " = ?";
        eq2.text = c.ToString() + op2 + d.ToString() + " = ?";

        if (op1 == " + ")
        {
            answer1 = a + b;
        }

        else
        {
            answer1 = a - b;
        }

        if (op2 == " + ")
        {
            answer2 = c + d;
        }
        else
        {
            answer2 = c - d;
        }

        // Change also buttons
        bouttonsControl = GameObject.FindGameObjectWithTag("button1").GetComponent<BouttonsControl>();
        bouttonsControl.ChangeBoutonsValueFirstBg(answer1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Update equation here : parameters : compt, difficulty
    public void UpdateEquation(int compt,float difficulty){
        bouttonsControl = GameObject.FindGameObjectWithTag("button1").GetComponent<BouttonsControl>();
        int diff = (int)difficulty;
        low = 0;
        high = 10+diff;
       
        if (difficulty < (float)7.5)
        {
            // need to update range here, depending on the difficulty
            // range increasing with the difficulty
            if (compt % 2 == 0)
            {
                randomIndex = Random.Range(0, 2);
                op1 = operations[randomIndex];

                a = Random.Range(low, high);
                b = Random.Range(low, high);

                if (op1 == " + ")
                {
                    answer1 = a + b;
                }
                else
                {
                    answer1 = a - b;
                }

                eq1.text = a.ToString() + op1 + b.ToString() + " = ?";

                bouttonsControl.ChangeBoutonsValueSecondBg(answer2);
            }
            else
            {
                randomIndex = Random.Range(0, 2);
                op2 = operations[randomIndex];

                c = Random.Range(low, high);
                d = Random.Range(low, high);

                if (op2 == " + ")
                {
                    answer2 = c + d;
                }
                else
                {
                    answer2 = c - d;
                }

                eq2.text = c.ToString() + op2 + d.ToString() + " = ?";
                bouttonsControl.ChangeBoutonsValueFirstBg(answer1);
            }
        }
        else
        {
            if (compt % 2 == 0)

            {
                randomIndex = Random.Range(0, 2);
                op1 = operations[randomIndex];
                randomIndex = Random.Range(0, 2);
                op3 = operations[randomIndex];

                a = Random.Range(low, high);
                b = Random.Range(low, high);
                a2 = Random.Range(low, high);

                eq1.text = a.ToString() + op1 + b.ToString() + op3 + a2.ToString() + " = ?";

                if (op1 == " + ")
                {
                    if (op3 == " + ")
                    {
                        answer1 = a+b+a2;
                    }

                }

                if (op1 == " + ")
                {
                    if (op3 == " - ")
                    {
                        answer1 = a + b - a2;
                    }
                }
                if (op1 == " - ")
                {
                    if (op3 == " + ")
                    {
                        answer1 = a - b + a2;
                    }

                }
                if (op1 == " - ")
                {
                    if (op3 == " - ")
                    {
                        answer1 = a - b - a2;
                    }

                }
                bouttonsControl.ChangeBoutonsValueSecondBg(answer2);

            }
            else
            {
                randomIndex = Random.Range(0, 2);
                op2 = operations[randomIndex];
                randomIndex = Random.Range(0, 2);
                op4 = operations[randomIndex];

                c = Random.Range(low, high);
                d = Random.Range(low, high);
                c2 = Random.Range(low, high);

                eq2.text = c.ToString() + op2 + d.ToString() + op4 + c2.ToString() + " = ?";

                if (op2 == " + ")
                {
                    if (op4 == " + ")
                    {
                        answer2 = c + d + c2;
                    }
                }

                if (op2 == " + ")
                {
                    if (op4 == " - ")
                    {
                        answer2 = c + d - c2;
                    }
                }
                if (op2 == " - ")
                {
                    if (op4 == " + ")
                    {
                        answer2 = c - d + c2;
                    }

                }
                if (op2 == " - ")
                {
                    if (op4 == " - ")
                    {
                        answer2 = c - d - c2;
                    }
                }

                bouttonsControl.ChangeBoutonsValueFirstBg(answer1);
            }


        }


    }

}
