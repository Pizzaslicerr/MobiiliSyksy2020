using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockyBridge : Bridge
{
    private GameObject sinkingPlatform;
    public float sinkingSpeed;

    void Start()
    {
        sinkingPlatform = GameObject.FindWithTag("SinkingPlatform");
        sinkingSpeed = sinkingPlatform.GetComponent<SinkingPlatform>().SinkingSpeed;

    }
    private void Update()
    {
        if (SinkingDetector.sinking)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, SinkingPlatform.BridgeSinkingTarget.transform.position, sinkingSpeed * Time.deltaTime);
        }
    }
}