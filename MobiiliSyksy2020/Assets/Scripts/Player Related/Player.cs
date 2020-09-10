using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float bridgeGrowthRate;
    private GameObject BridgeO;
    private Rigidbody2D BridgeRB;

    private Rigidbody2D FoxRB;

    public static bool BridgeTooLong;
    public static bool FoxMoving;

    public float Speed;
    public Transform FoxMovementTarget;
    public Transform FoxFallTarget;
    private Vector2 Direction;

    void Start()
    {

        BridgeRB.drag = 2;
        BridgeRB.mass = 3;
        BridgeRB.gravityScale = 2;
        FoxRB = gameObject.GetComponent<Rigidbody2D>();
        BridgeRB.simulated = false;
        Bridge.BridgeGrown = false;
    }

    void Update()
    {
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
            BridgeRB.simulated = true;
            Bridge.BridgeGrown = true;
        }


        if (FoxMoving)
        {
            MoveFoxCorrect();
        }
        if (BridgeTooLong)
        {
            MoveFoxTooFar();
        }
    }
    void MoveFoxCorrect()
    {
        BridgeRB.drag = 1000;
        BridgeRB.mass = 100;
        BridgeRB.gravityScale = 100;
        transform.position = Vector2.MoveTowards(transform.position, FoxMovementTarget.position, Speed * Time.deltaTime);
    }
    void MoveFoxTooFar()
    {
        BridgeRB.drag = 1000;
        BridgeRB.mass = 100;
        BridgeRB.gravityScale = 100;
        transform.position = Vector2.MoveTowards(transform.position, FoxFallTarget.position, Speed * Time.deltaTime);
    }
}
