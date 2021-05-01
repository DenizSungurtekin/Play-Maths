using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{

    bool isMute;
    public Button musicBoutonOn;
    public Button musicBoutonOff;
    public GameObject button;
    public GameObject button2;


    // Start is called before the first frame update
    void Start()
    {
        //Disable unMute button
        button2.SetActive(false);

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
        button2.SetActive(true);

        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
        

    }

    //unmute sound and activate the mute button
    public void UnMute()
    {
        
        button.SetActive(true);
        button2.SetActive(false);

        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
        

    }
}
