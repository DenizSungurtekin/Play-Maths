using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{

    public TMP_InputField name;
    public TMP_InputField age;

    public static string nameInput;
    public static string ageInput;

    public void Start() {

        name = GameObject.Find("Name").GetComponent<TMP_InputField>();
        age = GameObject.Find("Age").GetComponent<TMP_InputField>();


    }
    public void PlayGame()
    {
        // need a verification part here
        nameInput = name.text;
        ageInput = age.text;
        SceneManager.LoadScene(1);
    }
}
