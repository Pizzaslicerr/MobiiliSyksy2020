﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxDetector : MonoBehaviour
{
    public GameObject fox;

    public GameObject BridgePrefab;
    public GameObject LongBridgeDetector;
    public GameObject CorrectBridgeDetector;
    public GameObject NewBridgeSpawnPoint;
    public GameObject FoxMovementTargetOld;
    public GameObject FoxMovementTargetNew;
    public Transform FoxTPTarget;
    void Start()
    {
        NewBridgeSpawnPoint.SetActive(false);
        FoxMovementTargetNew.SetActive(false);
        FoxMovementTargetOld.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fox")
        {
            fox.transform.position = FoxTPTarget.position;

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
