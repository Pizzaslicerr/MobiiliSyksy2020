using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectBridgeLength : MonoBehaviour
{

    void Start()
    {
        Player.FoxMoving = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bridge")
        {
            Bridge.BridgeDown = true;
            Player.FoxMoving = true;
        }
    }
}
