using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public float fadeDurationDown;
    public float fadeDurationUp;
    public float targetVolumeDown;
    public float targetVolumeUp;

    public static bool playAudio;

    public static bool playBridgeAudio;
    void Start()
    {
        playAudio = true;
        playBridgeAudio = true;
    }

}
