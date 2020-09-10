using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxDetector : MonoBehaviour
{
    public GameObject Bridge;
    public Transform NewBridgeSpawnPoint;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fox")
        {
            Player.FoxMoving = false;
            Destroy(GameObject.FindGameObjectWithTag("Bridge"));
            Instantiate(Bridge, NewBridgeSpawnPoint.position, transform.rotation);
        }
    }
}
