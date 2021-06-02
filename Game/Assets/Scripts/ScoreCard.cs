using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCard : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI nameCard;
    public TextMeshProUGUI ageCard;

    public int score ;
    public string name;
    public string age;

    void Start()
    {
        textMesh =  GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        nameCard = GameObject.Find("Name").GetComponent<TextMeshProUGUI>();
        ageCard = GameObject.Find("Age").GetComponent<TextMeshProUGUI>();

        name = MainMenu.nameInput;
        age = MainMenu.ageInput;
    }

    void Update() {
        score = ScoreScript.scorefinal;
        textMesh.text = "Score : " + score.ToString();
        nameCard.text = "Name : " + name;
        ageCard.text = "Age : " + age;
    }

}
