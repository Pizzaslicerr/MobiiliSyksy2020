using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxDetector : MonoBehaviour
{
    public GameObject Fox;

    public GameObject Ramp;
    public GameObject BridgePrefab;
    public GameObject BridgeO;
    public GameObject LongBridgeDetector;
    public GameObject CorrectBridgeDetector;
    public GameObject NewBridgeSpawnPoint;
    public GameObject FoxMovementTargetOld;
    public GameObject FoxMovementTargetNew;
    void Start()
    {
        NewBridgeSpawnPoint.SetActive(false);
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
            GameObject.FindWithTag("BridgeSpawnPoint").SetActive(false);
            NewBridgeSpawnPoint.SetActive(true);
            //Activate ramp
            Ramp.SetActive(true);

            //Deactivate the previous movement target and activate a new one
            FoxMovementTargetNew.SetActive(true);
            FoxMovementTargetOld.SetActive(false);

            //Stop fox movement
            Player.FoxMoving = false;

            Fox.GetComponent<Player>().BridgeRest();

            /*BridgeO.transform.localScale = BridgePrefab.transform.localScale;
            BridgeO.transform.rotation = BridgePrefab.transform.rotation;
            BridgeO.transform.position = NewBridgeSpawnPoint.position;*/

            //Destroy old bridge object and instantiate new on the platform
            //Destroy(GameObject.FindGameObjectWithTag("Bridge"));
            //Instantiate(BridgePrefab, NewBridgeSpawnPoint.position, transform.rotation);

            //Deactivate old detectors
            LongBridgeDetector.SetActive(false);
            CorrectBridgeDetector.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
