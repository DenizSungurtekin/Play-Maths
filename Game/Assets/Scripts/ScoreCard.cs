using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class ScoreCard : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    public int score;
    public string name;
    public string age;

    private static string reportName;
    private static string reportPath;
    private static string reportSeparator = ",";

    private static string[] reportHeaders= new string[5] {
        "timestamp",
        "mappedScore",
        "HR",
        "EDA",
        "Score"
    };

    public string[] data = new string[5];
    public string[] datalimiter = new string[5];

    static void VerifyFile(string reportPath){
        if (!File.Exists(reportPath)) {
            createReport(reportPath);
        }
    }

    public static void createReport(string reportPath){
        using (StreamWriter sw = File.CreateText(reportPath)){
            string finalstring = "";
            for (int i=0;i<reportHeaders.Length;i++){
                if (finalstring != ""){
                    finalstring += reportSeparator;
                }
                finalstring += reportHeaders[i];
            }
            sw.WriteLine(finalstring);
        }
    }

    public static void AppendToReport(string[] strings,string reportPath){
        VerifyFile(reportPath);
        using (StreamWriter sw = File.AppendText(reportPath)) {
            string finalstring = "";
            for (int i=0; i < strings.Length; i++) {
                if (finalstring != "") {
                    finalstring += reportSeparator;
                }
                finalstring += strings[i];
            }
            sw.WriteLine(finalstring);
        }
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

    void Start()
    {
            textMesh = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();

            name = FirstCharToUpper(MainMenu.nameInput);
            age = MainMenu.ageInput;

            reportName = name + "_" + age + ".csv";
            reportPath = "./" + reportName;


            for (int i = 0; i < CameraControl.index; i++)
            {

                data[0] = CameraControl.time[i];
                data[1] = CameraControl.mappedScore[i].ToString();
                data[2] = CameraControl.HR[i].ToString();
                data[3] = CameraControl.EDA[i].ToString();
                data[4] = CameraControl.score[i].ToString();

                AppendToReport(data, reportPath);
            }


        datalimiter[0] = "Delimiter";
        datalimiter[1] = "Delimiter";
        datalimiter[2] = "Delimiter";
        datalimiter[3] = "Delimiter";
        datalimiter[4] = "Delimiter";
        AppendToReport(datalimiter, reportPath);


    }

    void Update() {
        score = ScoreScript.scorefinal;
        textMesh.text = "Score : " + score.ToString();


    }

}
