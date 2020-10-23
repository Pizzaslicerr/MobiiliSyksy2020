using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBridgeDetector : MonoBehaviour
{
    public GameObject BridgeCorrectLengthDetector;
    public GameObject FoxDetector;
    void Start()
    {
        Player.BridgeTooLong = false;
        BridgeCorrectLengthDetector.SetActive(true);
        FoxDetector.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bridge")
        {
            SinkingDetector.sinking = false;
            Bridge.BridgeDown = true;
            Player.BridgeTooLong = true;
            Player.FoxMoving = false;
            BridgeCorrectLengthDetector.SetActive(false);
            FoxDetector.SetActive(false);
        }
    }
}