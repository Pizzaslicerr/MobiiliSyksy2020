using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    //Making these variables easily accessible from all scripts
    public static bool BridgeGrown;
    public static bool BridgeDown;

    private GameObject sinkingPlatform;
    public float sinkingSpeed;

    void Start()
    {
        sinkingPlatform = GameObject.FindWithTag("SinkingPlatform");
        //To make sure a new bridge always has these variables set to false
        BridgeGrown = false;
        BridgeDown = false;
        sinkingSpeed = sinkingPlatform.GetComponent<SinkingPlatform>().SinkingSpeed;

        if (Player.BridgeRB != null)
        {
            Player.BridgeRB.simulated = false;
        }
    }
    private void Update()
    {
        if (SinkingDetector.sinking)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, SinkingPlatform.BridgeSinkingTarget.transform.position, sinkingSpeed * Time.deltaTime);
        }
    }
}