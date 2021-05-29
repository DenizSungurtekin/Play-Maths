using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCard : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public int score ;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        score = ScoreScript.scorefinal;
        textMesh.text = "Score : " + score.ToString();
    }

}
