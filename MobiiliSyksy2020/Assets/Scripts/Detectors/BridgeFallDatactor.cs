using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class BridgeFallDatactor : MonoBehaviour
{
    public GameObject Fox;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fox")
        {
            SceneHandler.instance.SceneReload(this.gameObject.scene.buildIndex, LoadingScreens.Leaves);
        }
        else if (collision.tag == "Bridge")
        {
            Fox.GetComponent<Player>().BridgeReset();
        }
    }
}
