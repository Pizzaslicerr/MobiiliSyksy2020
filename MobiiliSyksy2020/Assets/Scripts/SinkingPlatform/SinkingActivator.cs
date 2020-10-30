using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkingActivator : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<SinkingPlatform>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fox")
        {
            gameObject.GetComponent<SinkingPlatform>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Fox")
        {
            gameObject.GetComponent<SinkingPlatform>().enabled = false;
        }
    }
}
