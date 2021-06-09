using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class AgeName : MonoBehaviour
{

    public TextMeshProUGUI nameCard;
    public TextMeshProUGUI ageCard;

    public string name;
    public string age;

    // Start is called before the first frame update
    void Start()
    {
        nameCard = GameObject.Find("Name").GetComponent<TextMeshProUGUI>();
        ageCard = GameObject.Find("Age").GetComponent<TextMeshProUGUI>();
        name = FirstCharToUpper(MainMenu.nameInput);
        age = MainMenu.ageInput;
    }

    // Update is called once per frame
    void Update()
    {
        nameCard.text = "Name : " + name;
        ageCard.text = "Age : " + age;

    }

    public static string FirstCharToUpper(string s)
    {
        // Check for empty string.
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        // Return char and concat substring.
        return char.ToUpper(s[0]) + s.Substring(1);
    }
}
