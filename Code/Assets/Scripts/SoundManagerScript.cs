using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip good, bad,gameover;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        good = Resources.Load<AudioClip>("good");
        bad = Resources.Load<AudioClip>("bad");
        gameover = Resources.Load<AudioClip>("gameover");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "good":
                audioSrc.PlayOneShot(good);
                break;

            case "bad":
                audioSrc.PlayOneShot(bad);
                break;

            case "gameover":
                 audioSrc.PlayOneShot(gameover);
                 break;
        }

    }
}
