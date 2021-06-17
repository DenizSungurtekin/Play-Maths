using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class BouttonsControl : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;

    public GameObject bouton1;
    public GameObject bouton2;
    public GameObject bouton3;
    public GameObject bouton4;



    public int position_answer,selected_answer,min_range,max_range, answer,one,vie_perdu,incertitude;
    public EquationControl equationControl;
    public List<GameObject> btn = new List<GameObject>();
    public List<GameObject> hearts = new List<GameObject>();
    //GameObject[] btn;
    //GameObject[] hearts;
    

    void Start()
    {
        vie_perdu = 0;
        bouton1 = GameObject.Find("Button1");
        bouton2 = GameObject.Find("Button2");
        bouton3 = GameObject.Find("Button3");
        bouton4 = GameObject.Find("Button4");

        btn.Add(bouton1);
        btn.Add(bouton2);
        btn.Add(bouton3);
        btn.Add(bouton4);

        heart1 = GameObject.Find("Heart1");
        heart2 = GameObject.Find("Heart2");
        heart3 = GameObject.Find("Heart3");
        heart4 = GameObject.Find("Heart4");

        hearts.Add(heart1);
        hearts.Add(heart2);
        hearts.Add(heart3);
        hearts.Add(heart4);

        selected_answer = 0; //initial value if no button are selected
    }

    // Update is called once per frame
    void Update()
    {
        // determine which button is pressed
        btn[selected_answer].GetComponentInChildren<Text>().color = Color.green;

        if (Input.GetKeyDown(KeyCode.Alpha1) | Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow))
        {
            btn[selected_answer].GetComponentInChildren<Text>().color = Color.white;
            selected_answer = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) | Input.GetKeyDown(KeyCode.S) | Input.GetKeyDown(KeyCode.UpArrow))
        {
            btn[selected_answer].GetComponentInChildren<Text>().color = Color.white;
            selected_answer = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) | Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow))
        {
            btn[selected_answer].GetComponentInChildren<Text>().color = Color.white;
            selected_answer = 2;

        }
        if (Input.GetKeyDown(KeyCode.Alpha4) | Input.GetKeyDown(KeyCode.F) | Input.GetKeyDown(KeyCode.DownArrow))
        {
            btn[selected_answer].GetComponentInChildren<Text>().color = Color.white;
            selected_answer = 3;

        }
    }

    public void ChangeBoutonsValueFirstBg(int answer,float difficulty)
    {
        //GameObject[] btn = GameObject.FindGameObjectsWithTag("buttons");
        int[] boutton_values = new int[4];
        position_answer = Random.Range(0, 4);

        incertitude = (int)((float)14.0 - difficulty);
        Debug.Log("inc" + incertitude);

        min_range = answer - incertitude;
        max_range = answer + incertitude;

         for (int i = 0; i < btn.Count; i++)
            {
                if (i == position_answer)
                {
                    //we check for location value and assign it to the corresponding ans button
                    btn[i].GetComponentInChildren<Text>().text = "" + answer;
                    boutton_values[i] = answer;
                }
                else
                {
                    //for other ans button we assign random values in a specific range from the answer
                    one = Random.Range(min_range, max_range);
                    btn[i].GetComponentInChildren<Text>().text = "" + one;

                    while (btn[i].GetComponentInChildren<Text>().text == "" + answer | boutton_values.Contains(one) )
                    {
                    one = Random.Range(min_range, max_range);
                    //we make sure that only one button has answer values
                    btn[i].GetComponentInChildren<Text>().text = "" + one;
                    }
                boutton_values[i] = one;

                }

            }
    }

    public void ChangeBoutonsValueSecondBg(int answer, float difficulty)
    {
        //GameObject[] btn = GameObject.FindGameObjectsWithTag("buttons");
        int[] boutton_values = new int[4];
        position_answer = Random.Range(0, 4);

        incertitude = (int)((float)16 - difficulty);
        Debug.Log("inc"+ incertitude);

        min_range = answer - incertitude;
        max_range = answer + incertitude;

        for (int i = 0; i < btn.Count; i++)
        {
            if (i == position_answer)
            {
                //we check for location value and assign it to the corresponding ans button
                btn[i].GetComponentInChildren<Text>().text = "" + answer;
                boutton_values[i] = answer;
            }
            else
            {
                //for other ans button we assign random values in a specific range from the answer
                one = Random.Range(min_range, max_range);
                btn[i].GetComponentInChildren<Text>().text = "" + one;

                while (btn[i].GetComponentInChildren<Text>().text == "" + answer | boutton_values.Contains(one))
                {
                    one = Random.Range(min_range, max_range);
                    //we make sure that only one button has answer values
                    btn[i].GetComponentInChildren<Text>().text = "" + one;
                }
                boutton_values[i] = one;

            }
        }
    }



    public void CheckButtonValueFirstBg(float difficulty)
    {
        equationControl = GameObject.FindGameObjectWithTag("equations").GetComponent<EquationControl>();

        int diff = (int)difficulty;
        // Update for score depends on :
        // Need to import these parameters : Time, Difficulty
        // to compute the score par ex : score = time * Difficulty * cst


        if (btn[selected_answer].GetComponentInChildren<Text>().text == equationControl.answer1.ToString())
        {
            SoundManagerScript.PlaySound("good");
            ScoreScript.scorevalue += 10 * diff;
        }
        else
        {
            hearts[vie_perdu].SetActive(false);
            vie_perdu += 1;
            SoundManagerScript.PlaySound("bad");
            if (ScoreScript.scorevalue - (10 * (11 - diff)) < 0)
            {
                ScoreScript.scorevalue = 0;
            }
            else { ScoreScript.scorevalue -= 10 * (11 - diff); }

        }

        if (vie_perdu == 4) {
            SoundManagerScript.PlaySound("gameover");
            SceneManager.LoadScene(2);
        } // Game Over : Scene redirect to the Scorecard Scene


    }

    public void CheckButtonValueSecondBg(float difficulty)
    {

    equationControl = GameObject.FindGameObjectWithTag("equations").GetComponent<EquationControl>();

        int diff = (int)difficulty;
        // Update for score depends on :
        // Need to import these parameters : Time, Difficulty
        // to compute the score par ex : score = time * Difficulty * cst
        if (btn[selected_answer].GetComponentInChildren<Text>().text == equationControl.answer2.ToString())
        {
            SoundManagerScript.PlaySound ("good");
            ScoreScript.scorevalue +=  10*diff;
        }
        else
        {
            hearts[vie_perdu].SetActive(false);
            vie_perdu += 1;
            SoundManagerScript.PlaySound("bad");



            if ((ScoreScript.scorevalue - (10 * (11 - diff))) < 0)
            {
                ScoreScript.scorevalue = 0;
            }
            else { ScoreScript.scorevalue -= 10 * (11 - diff); }

            if (vie_perdu == 4) {
                SoundManagerScript.PlaySound("gameover");
                SceneManager.LoadScene(2);

            } // Game Over : Scene redirect to the Scorecard Scene

        }


    }




}
