﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject paw1;
    public GameObject paw2;
    public GameObject paw3;
    public GameObject paw4;
    public GameObject paw5;
    public GameObject paw6;
    public GameObject paw7;
    public GameObject paw8;
    public GameObject paw9;
    public GameObject paw10;

    public int Paws;

    private bool screenPressed = false;

    public float bridgeGrowthRate;
    //private GameObject BridgeO;
    public GameObject BridgeO;
    public GameObject BridgePrefab;
    public static Rigidbody2D BridgeRB;
    private GameObject BridgeSpawnPoint;

    private Rigidbody2D FoxRB;

    public static bool BridgeTooLong;
    public static bool FoxMoving;

    public float Speed;
    private GameObject FoxMovementTarget;
    public Transform FoxFallTarget;

    Vector3 v;
    Vector3 temp;

    void Start()
    {
        Paws = 10;
        FoxRB = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Finding objects with tags so there's no need to fiddle around with public game objects
        FoxMovementTarget = GameObject.FindWithTag("MovementTarget");
        //BridgeO = GameObject.FindWithTag("Bridge");
        BridgeRB = BridgeO.GetComponent<Rigidbody2D>();
        if (!Bridge.BridgeGrown && Input.GetMouseButton(0))
        {
            //Growing the bridge while pressing and holding the screen
            v = BridgeO.transform.localScale;
            temp = v;
            v.y = v.y + bridgeGrowthRate * Time.deltaTime;
            BridgeO.transform.localScale = v;
            screenPressed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (!Bridge.BridgeDown && !Bridge.BridgeGrown)
            {
                Paws = Paws - 1;
            }
            v.y = temp.y;
            //Make the bridge's rigidbody simulated so it will fall when you let go of the screen
            BridgeRB.simulated = true;
            Bridge.BridgeGrown = true;
            screenPressed = false;
        }
        //The paw system, feel free to replace with something more sensible
        if (Paws == 9)
        {
            paw10.SetActive(false);
        }
        if (Paws == 8)
        {
            paw9.SetActive(false);
        }
        if (Paws == 7)
        {
            paw8.SetActive(false);
        }
        if (Paws == 6)
        {
            paw7.SetActive(false);
        }
        if (Paws == 5)
        {
            paw6.SetActive(false);
        }
        if (Paws == 4)
        {
            paw5.SetActive(false);
        }
        if (Paws == 3)
        {
            paw4.SetActive(false);
        }
        if (Paws == 2)
        {
            paw3.SetActive(false);
        }
        if (Paws == 1)
        {
            paw2.SetActive(false);
        }
        if (Paws == 0)
        {
            paw1.SetActive(false);
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }


        if (FoxMoving)
        {
            MoveFoxCorrect();
        }
        if (BridgeTooLong)
        {
            MoveFoxTooFar();
        }

        //Debug.DrawLine(gameObject.transform.position, BridgeSpawnPoint.transform.position, Color.red);
    }
    void MoveFoxCorrect()
    {
        //Moving the fox correctly to the next platform
        BridgeRB.constraints = RigidbodyConstraints2D.FreezePosition;
        BridgeRB.freezeRotation = true;
        transform.position = Vector2.MoveTowards(transform.position, FoxMovementTarget.transform.position, Speed * Time.deltaTime);
    }
    void MoveFoxTooFar()
    {
        //Moving the fox too far so it falls
        BridgeRB.constraints = RigidbodyConstraints2D.FreezePosition;
        BridgeRB.freezeRotation = true;
        transform.position = Vector2.MoveTowards(transform.position, FoxFallTarget.transform.position, Speed * Time.deltaTime);
    }

    public void BridgeRest()
    {
        BridgeSpawnPoint = GameObject.FindWithTag("BridgeSpawnPoint");
        Bridge.BridgeGrown = false;
        BridgeRB.simulated = false;
        Bridge.BridgeDown = false;
        BridgeRB.freezeRotation = false;
        BridgeRB.constraints = RigidbodyConstraints2D.None;
        BridgeO.transform.localScale = BridgePrefab.transform.localScale;
        BridgeO.transform.rotation = BridgePrefab.transform.rotation;
        BridgeO.transform.position = BridgeSpawnPoint.transform.position;
    }
}
