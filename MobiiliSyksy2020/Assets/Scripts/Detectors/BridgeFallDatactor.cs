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
            /*BridgeO.transform.localScale = BridgePrefab.transform.localScale;
            BridgeO.transform.rotation = BridgePrefab.transform.rotation;
            BridgeO.transform.position = BridgeSpawnPoint.position;*/
            //If the bridge falls, it gets spawned again on the platform
            //Destroy(GameObject.FindGameObjectWithTag("Bridge"));
            //Instantiate(BridgePrefab, BridgeSpawnPoint.position, transform.rotation);
        }
    }
}
