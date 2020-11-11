using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform MoveNode1;
    public Transform MoveNode2;
    private Transform CurrentTarget;

    private GameObject NewBridgeSpawnpoint;
    private GameObject FoxTpPoint;

    private bool PlatformMoving;
    public static bool FoxOnPlatform;

    public float MovingSpeed;

    private GameObject Fox;
    private GameObject bridge;
    private void Start()
    {
        bridge = GameObject.FindWithTag("Bridge");
        Fox = GameObject.FindWithTag("Fox");
        PlatformMoving = true;
        CurrentTarget = MoveNode1;
        FoxOnPlatform = false;
    }
    void Update()
    {
        if (PlatformMoving)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, CurrentTarget.position, MovingSpeed * Time.deltaTime);
        }
        if (FoxOnPlatform && !Bridge.BridgeGrown)
        {
            FoxTpPoint = GameObject.FindWithTag("FoxTpTarget");
            Fox.transform.position = FoxTpPoint.transform.position;
            Fox.transform.rotation = gameObject.transform.rotation;
            NewBridgeSpawnpoint = GameObject.FindWithTag("BridgeSpawnPoint");
            bridge.transform.position = NewBridgeSpawnpoint.transform.position;
            this.transform.position = Vector2.MoveTowards(this.transform.position, CurrentTarget.position, MovingSpeed * Time.deltaTime);
        }
        if (Bridge.BridgeDown)
        {
            FoxOnPlatform = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bridge")
        {
            PlatformMoving = false;
        }
        if (collision.tag == "MoveNode1")
        {
            CurrentTarget = MoveNode2;
        }
        if (collision.tag == "MoveNode2")
        {
            CurrentTarget = MoveNode1;
        }
        if (collision.tag == "Fox")
        {
            FoxOnPlatform = true;
        }
    }
}