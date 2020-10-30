using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkingPlatform : MonoBehaviour
{
    public Transform SinkingTarget;
    public static GameObject BridgeSinkingTarget;
    private GameObject bridge;

    public static bool SinkBridge;

    public float SinkingSpeed;

    private void Start()
    {
        bridge = GameObject.FindWithTag("Bridge");
        BridgeSinkingTarget = GameObject.FindWithTag("BridgeSinkTarget");
    }
    void Update()
    {
        if (SinkingDetector.sinking)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, SinkingTarget.position, SinkingSpeed * Time.deltaTime);
        }
    }
}