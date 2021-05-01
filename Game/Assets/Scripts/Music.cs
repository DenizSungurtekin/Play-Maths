using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{

    public Button musicBoutonOn;
    public Button musicBoutonOff;

    public GameObject button;
    public GameObject button1;



    // Start is called before the first frame update
    void Start()
    {
        if (button.activeSelf)  //Check if mute button is actif
            {
            //Disable unMute button if the mute button is actif. ( The start function is run after each event)
            button1.SetActive(false);
            }

        Button btn = musicBoutonOn.GetComponent<Button>();
        Button btnOff = musicBoutonOff.GetComponent<Button>();

        //Add Event onClick
        btn.onClick.AddListener(Mute);
        btnOff.onClick.AddListener(UnMute);

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    //Mute sound and activate the unmute button
    public void Mute()
    {
        button.SetActive(false);
        button1.SetActive(true);

        AudioListener.volume = 0;
    }

    //Unmute sound and activate the mute button
    public void UnMute()
    {
        button1.SetActive(false);
        button.SetActive(true);

        AudioListener.volume = 1;   
    }
}
