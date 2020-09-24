using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject[] paws;

    private int pawsUsed;

    private bool screenPressed = false;

    public float bridgeGrowthRate;
    private GameObject BridgeO;
    //public GameObject BridgeO;
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
        FoxRB = gameObject.GetComponent<Rigidbody2D>();
        BridgeO = GameObject.FindWithTag("Bridge");
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
                paws[pawsUsed].SetActive(false);
                pawsUsed++;
            }
            v.y = temp.y;
            //Make the bridge's rigidbody simulated so it will fall when you let go of the screen
            BridgeRB.simulated = true;
            Bridge.BridgeGrown = true;
            screenPressed = false;
        }


        if (FoxMoving)
        {
            MoveFoxCorrect();
        }
        if (BridgeTooLong)
        {
            MoveFoxTooFar();
        }

        Debug.DrawLine(gameObject.transform.position, BridgeO.transform.position, Color.red);
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
        //commented out for now, bizarrely this runs even when pawsUsed doesn't equal paws.Length
        /*if (pawsUsed == paws.Length)
        {
            Debug.Log("Why does this run?");
            SceneHandler.instance.ReloadScene(this.gameObject.scene.buildIndex, LoadingScreens.Leaves);
        }*/
        //Find the current active spawn point for the bridge
        BridgeSpawnPoint = GameObject.FindWithTag("BridgeSpawnPoint");
        //Reset variables and remove bridge constraints
        Bridge.BridgeGrown = false;
        BridgeRB.simulated = false;
        Bridge.BridgeDown = false;
        BridgeRB.freezeRotation = false;
        BridgeRB.constraints = RigidbodyConstraints2D.None;
        //Reset the bridge to the next spot, or the current one if it fell
        BridgeO = GameObject.FindWithTag("Bridge");
        BridgeO.transform.localScale = BridgePrefab.transform.localScale;
        BridgeO.transform.rotation = BridgePrefab.transform.rotation;
        BridgeO.transform.position = BridgeSpawnPoint.transform.position;
    }
}