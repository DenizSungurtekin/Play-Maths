using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouttonsControl : MonoBehaviour
{

    public float answer,one;
    public int position_answer,selected_answer;
    public EquationControl equationControl;
    GameObject[] btn;



    // Start is called before the first frame update
    void Start()
    {
        btn = GameObject.FindGameObjectsWithTag("buttons");
        selected_answer = 0; //initial value if no button are selected

    }

    // Update is called once per frame
    void Update()
    {
        // determine which button is pressed
        btn[selected_answer].GetComponentInChildren<Text>().color = Color.green;

        //Debug.Log("Text: " + selected_answer);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            btn[selected_answer].GetComponentInChildren<Text>().color = Color.white;
            selected_answer = 0;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            btn[selected_answer].GetComponentInChildren<Text>().color = Color.white;
            selected_answer = 1;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            btn[selected_answer].GetComponentInChildren<Text>().color = Color.white;
            selected_answer = 2;

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            btn[selected_answer].GetComponentInChildren<Text>().color = Color.white;
            selected_answer = 3;

        }





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



    public void CheckButtonValueFirstBg()
    {

        // Update for score depends on :
        // Need to import these parameters : Time, Difficulty
        // to compute the score par ex : score = time * Difficulty * cst
        if (btn[selected_answer].GetComponentInChildren<Text>().text == answer.ToString())
        {
            ScoreScript.scorevalue += 10;
        }
        else
        {
            ScoreScript.scorevalue -= 10;
        }


    }

    public void CheckButtonValueSecondBg()
    {

        // Update for score depends on :
        // Need to import these parameters : Time, Difficulty
        // to compute the score par ex : score = time * Difficulty * cst
        if (btn[selected_answer].GetComponentInChildren<Text>().text == answer.ToString())
        {
            ScoreScript.scorevalue += 10;
        }
        else
        {
            ScoreScript.scorevalue -= 10;
        }


    }



}
