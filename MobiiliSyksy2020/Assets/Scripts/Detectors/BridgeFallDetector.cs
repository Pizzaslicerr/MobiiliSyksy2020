﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class BridgeFallDetector : MonoBehaviour
{
    public GameObject pawHandler;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fox")
        {
            SceneHandler.instance.SceneReload(this.gameObject.scene.buildIndex, LoadingScreens.Leaves);
        }
        else if (collision.tag == "Bridge")
        {
            pawHandler.GetComponent<PawHandler>().BridgeReset();
        }
    }
}