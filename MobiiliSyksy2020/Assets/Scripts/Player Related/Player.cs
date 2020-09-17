using System.Collections;
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

    public float bridgeGrowthRate;
    private GameObject BridgeO;
    private Rigidbody2D BridgeRB;

    private Rigidbody2D FoxRB;

    public static bool BridgeTooLong;
    public static bool FoxMoving;

    public float Speed;
    private GameObject FoxMovementTarget;
    public Transform FoxFallTarget;

    void Start()
    {
        Paws = 10;
        FoxRB = gameObject.GetComponent<Rigidbody2D>();
        BridgeRB.simulated = false;
        Bridge.BridgeGrown = false;
    }

    void Update()
    {
        FoxMovementTarget = GameObject.FindWithTag("MovementTarget");
        BridgeO = GameObject.FindWithTag("Bridge");
        BridgeRB = GameObject.FindWithTag("Bridge").GetComponent<Rigidbody2D>();
        if (!Bridge.BridgeGrown && Input.GetMouseButton(0))
        {
            Vector3 v = BridgeO.transform.localScale;
            v.y = v.y + bridgeGrowthRate;
            BridgeO.transform.localScale = v;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (!Bridge.BridgeDown && !Bridge.BridgeGrown)
            {
                Paws = Paws - 1;
            }
            BridgeRB.simulated = true;
            Bridge.BridgeGrown = true;
        }

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
            SceneManager.LoadScene("Teemu");
        }


        if (FoxMoving)
        {
            MoveFoxCorrect();
        }
        if (BridgeTooLong)
        {
            MoveFoxTooFar();
        }

        Debug.DrawLine(gameObject.transform.position, FoxFallTarget.transform.position, Color.red);
    }
    void MoveFoxCorrect()
    {
        BridgeRB.constraints = RigidbodyConstraints2D.FreezePosition;
        BridgeRB.freezeRotation = true;
        transform.position = Vector2.MoveTowards(transform.position, FoxMovementTarget.transform.position, Speed * Time.deltaTime);
    }
    void MoveFoxTooFar()
    {
        BridgeRB.constraints = RigidbodyConstraints2D.FreezePosition;
        BridgeRB.freezeRotation = true;
        transform.position = Vector2.MoveTowards(transform.position, FoxFallTarget.transform.position, Speed * Time.deltaTime);
    }
}
