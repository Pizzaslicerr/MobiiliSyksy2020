using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BridgeFallDatactor : MonoBehaviour
{
    public Transform BridgeSpawnPoint;
    public GameObject BridgePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fox")
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
        else if (collision.tag == "Bridge")
        {
            Destroy(GameObject.FindGameObjectWithTag("Bridge"));
            Instantiate(BridgePrefab, BridgeSpawnPoint.position, transform.rotation);
        }
    }
}
