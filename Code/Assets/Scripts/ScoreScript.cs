using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public static int scorevalue = 0 ;
    public static int scorefinal ;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        scorevalue = 0;
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scorefinal = scorevalue;
        score.text = ": " + scorevalue;
    }
}
