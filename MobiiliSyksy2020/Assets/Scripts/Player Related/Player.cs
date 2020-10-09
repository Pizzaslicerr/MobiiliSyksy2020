using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class Player : MonoBehaviour
{

    private bool screenPressed = false;

    public float bridgeGrowthRate;
    public static GameObject BridgeO;
    public static Rigidbody2D BridgeRB;
    public static GameObject BridgeSpawnPoint;
    public float BridgeMaxLength;

    private Rigidbody2D FoxRB;
    public Animator anim;

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
        if (Input.GetMouseButton(0))
        {

            if (!Bridge.BridgeGrown)
            {
                //Growing the bridge while pressing and holding the screen
                v = BridgeO.transform.localScale;
                temp = v;
                v.y = v.y + bridgeGrowthRate * Time.deltaTime;
                BridgeO.transform.localScale = v;
                screenPressed = true;

            }

        }
        if (Input.GetMouseButtonUp(0) || BridgeO.transform.localScale.y > BridgeMaxLength)
        {
            if(BridgeO.transform.localScale.y < 80f)
            {
                v.y = 80f;
                BridgeO.transform.localScale = v;
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
            Animate();
        }
        if (BridgeTooLong)
        {
            MoveFoxTooFar();
            Animate();
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

    void Animate()
    {
        anim.SetFloat("isMoving", 1f);
        
    }

}
