using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkingDetector : MonoBehaviour
{
    public static bool sinking;
    void Start()
    {
        sinking = false;
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fox")
        {
            sinking = true; 
        }
    }

}
