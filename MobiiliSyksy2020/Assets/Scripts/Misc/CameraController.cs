using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject Fox;
    void Start()
    {
        Fox = GameObject.FindWithTag("Fox");
    }

    void Update()
    {
        gameObject.transform.position = new Vector3 (Fox.transform.position.x + 3.8f, 0, -10);
    }
}
