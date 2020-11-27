using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxDetector : MonoBehaviour
{
    private GameObject fox;

    public GameObject BridgePrefab;
    public GameObject LongBridgeDetector;
    public GameObject CorrectBridgeDetector;
    public GameObject NewBridgeSpawnPoint;
    public GameObject FoxMovementTargetOld;
    public GameObject FoxMovementTargetNew;
    public GameObject FoxTPTarget;

    private AudioSource playerAS;
    void Start()
    {
        fox = GameObject.FindWithTag("Fox");
        NewBridgeSpawnPoint.SetActive(false);
        FoxMovementTargetNew.SetActive(false);
        FoxMovementTargetOld.SetActive(true);
        FoxTPTarget.SetActive(false);
        playerAS = fox.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fox")
        {
            PlayerAudio.playAudio = true;
            PlayerAudio.playBridgeAudio = true;
            playerAS.Stop();

            GameObject.FindWithTag("FoxTpTarget").SetActive(false);
            FoxTPTarget.SetActive(true);
            fox.transform.position = FoxTPTarget.transform.position;

            GameObject.FindWithTag("BridgeSpawnPoint").SetActive(false);
            NewBridgeSpawnPoint.SetActive(true);

            //Deactivate the previous movement target and activate a new one
            FoxMovementTargetNew.SetActive(true);
            FoxMovementTargetOld.SetActive(false);

            //Stop fox movement
            Player.FoxMoving = false;
            
            fox.GetComponent<PawHandler>().BridgeReset();
            

            //Deactivate old detectors
            LongBridgeDetector.SetActive(false);
            CorrectBridgeDetector.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
