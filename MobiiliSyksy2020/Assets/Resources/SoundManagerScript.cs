using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip Button1Sound, Button2Sound, Button3Sound, Rise1Sound, Rise2Sound,
                            Rise3Sound, Walk1Sound, Walk2Sound;

    static AudioSource audioSrc;
    
    // Start is called before the first frame update
    void Start()
    {
        Button1Sound = Resources.Load<AudioClip>("Button1");
        Button2Sound = Resources.Load<AudioClip>("Button2");
        Button3Sound = Resources.Load<AudioClip>("Button3");
        Rise1Sound = Resources.Load<AudioClip>("Rise1");
        Rise2Sound = Resources.Load<AudioClip>("Rise2");
        Rise3Sound = Resources.Load<AudioClip>("Rise3");
        Walk1Sound = Resources.Load<AudioClip>("Walk1");
        Walk2Sound = Resources.Load<AudioClip>("Walk2");
        
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
            case "Button1":
                audioSrc.PlayOneShot(Button1Sound);
                break;
            case "Button2":
                audioSrc.PlayOneShot(Button2Sound);
                break;
            case "Button3":
                audioSrc.PlayOneShot(Button3Sound);
                break;
            case "Rise1":
                audioSrc.PlayOneShot(Rise1Sound);
                break;
            case "Rise2":
                audioSrc.PlayOneShot(Rise2Sound);
                break;
            case "Walk1":
                audioSrc.PlayOneShot(Walk1Sound);
                break;
            case "Walk2":
                audioSrc.PlayOneShot(Walk2Sound);
                break;
            
        }
    }
}
