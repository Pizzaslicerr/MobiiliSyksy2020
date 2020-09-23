using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BridgeFallDatactor : MonoBehaviour
{
    public Transform BridgeSpawnPoint;
    public GameObject BridgePrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fox")
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
        else if (collision.tag == "Bridge")
        {
            //If the bridge falls, it gets spawned again on the platform
            Destroy(GameObject.FindGameObjectWithTag("Bridge"));
            Instantiate(BridgePrefab, BridgeSpawnPoint.position, transform.rotation);
        }
    }
}
