using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxDetector : MonoBehaviour
{
    public GameObject Ramp;
    public GameObject BridgePrefab;
    public GameObject LongBridgeDetector;
    public GameObject CorrectBridgeDetector;
    public Transform NewBridgeSpawnPoint;
    public GameObject FoxMovementTargetOld;
    public GameObject FoxMovementTargetNew;
    void Start()
    {
        FoxMovementTargetNew.SetActive(false);
        FoxMovementTargetOld.SetActive(true);
        Ramp.SetActive(false);
    }

    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fox")
        {
            Ramp.SetActive(true);
            FoxMovementTargetNew.SetActive(true);
            FoxMovementTargetOld.SetActive(false);
            Player.FoxMoving = false;
            Destroy(GameObject.FindGameObjectWithTag("Bridge"));
            Instantiate(BridgePrefab, NewBridgeSpawnPoint.position, transform.rotation);
            LongBridgeDetector.SetActive(false);
            CorrectBridgeDetector.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
