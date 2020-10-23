using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkingPlatform : MonoBehaviour
{
    public Transform SinkingTarget;
    public Transform BridgeSinkingTarget;
    public GameObject bridge;

    public float SinkingSpeed;

    private void Start()
    {
        bridge = GameObject.FindWithTag("Bridge");
    }
    void Update()
    {
        if (SinkingDetector.sinking)
        {
            transform.position = Vector2.MoveTowards(transform.position, SinkingTarget.position, SinkingSpeed * Time.deltaTime);
            bridge.transform.position = Vector2.MoveTowards(bridge.transform.position, BridgeSinkingTarget.position, SinkingSpeed * Time.deltaTime);
        }
    }
}
