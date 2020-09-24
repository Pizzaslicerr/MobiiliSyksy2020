using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BridgeFallDatactor : MonoBehaviour
{
    public GameObject Fox;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fox")
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
        else if (collision.tag == "Bridge")
        {
            Fox.GetComponent<Player>().BridgeRest();
        }
    }
}
