using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip walk;
    public AudioSource playerAS;

    public float fadeDurationDown;
    public float fadeDurationUp;
    public float targetVolumeDown;
    public float targetVolumeUp;
    void Start()
    {
        
    }

    void Update()
    {
        if (!Player.FoxMoving)
        {
            StartCoroutine(AudioFade.StartFade(playerAS, fadeDurationDown, targetVolumeDown));
        }
        if (Player.FoxMoving)
        {
            playerAS.volume = 0.1f;
        }
    }

    void FootStep()
    {
        playerAS.PlayOneShot(walk);
    }
}
