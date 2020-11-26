using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class Player : MonoBehaviour
{

    public AudioClip walk;
    public AudioSource playerAS;
    private bool screenPressed = false;

    public float BridgeGrowthRate;
    public static GameObject BridgeO;
    public static Rigidbody2D BridgeRB;
    public static GameObject BridgeSpawnPoint;
    public float BridgeMaxLength;

    public LayerMask LayerMask;

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
        anim = gameObject.GetComponent<Animator>();
        FoxFallTarget = GameObject.FindWithTag("FoxFallTarget").transform;
        FoxMoving = false;
    }

    void Update()
    {
        //Finding objects with tags so there's no need to fiddle around with public game objects
        FoxMovementTarget = GameObject.FindWithTag("MovementTarget");
        //BridgeO = GameObject.FindWithTag("Bridge");
        BridgeRB = BridgeO.GetComponent<Rigidbody2D>();

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, LayerMask);

        if (Input.GetMouseButton(0) && hit.collider != null && hit.collider.tag == "PressDetector")
        {

            if (!Bridge.BridgeGrown)
            {
                //Growing the bridge while pressing and holding the screen
                v = BridgeO.transform.localScale;
                temp = v;
                v.y = v.y + BridgeGrowthRate * Time.deltaTime;
                BridgeO.transform.localScale = v;
                screenPressed = true;

            }

        }
        if (Input.GetMouseButtonUp(0) && screenPressed || BridgeO.transform.localScale.y > BridgeMaxLength && screenPressed)
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
        }
        if (BridgeTooLong)
        {
            MoveFoxTooFar();
        }

            Debug.DrawLine(gameObject.transform.position, BridgeO.transform.position, Color.red);
    }

    void FixedUpdate()
    {
        var velocity = FoxRB.velocity;

        //Detects if player is still and plays idle animation
        if (velocity.magnitude <= 0.0f)
        {
            anim.SetFloat("MoveX", 0f);
   
        }
    }

    void MoveFoxCorrect()
    {
        if (PlayerAudio.playAudio)
        {
            playerAS.PlayOneShot(walk);
            PlayerAudio.playAudio = false;
        }
        //Moving the fox correctly to the next platform
        BridgeRB.constraints = RigidbodyConstraints2D.FreezePosition;
        BridgeRB.freezeRotation = true;
        transform.position = Vector2.MoveTowards(transform.position, FoxMovementTarget.transform.position, Speed * Time.deltaTime);
        //Plays walk animation
        anim.SetFloat("MoveX", 1f);
    }
    void MoveFoxTooFar()
    {
        if (PlayerAudio.playAudio)
        {
            playerAS.PlayOneShot(walk);
            PlayerAudio.playAudio = false;
        }
        //Moving the fox too far so it falls
        BridgeRB.constraints = RigidbodyConstraints2D.FreezePosition;
        BridgeRB.freezeRotation = true;
        transform.position = Vector2.MoveTowards(transform.position, FoxFallTarget.transform.position, Speed * Time.deltaTime);
        //Plays walk animation
        anim.SetFloat("MoveX", 1f);
    }

}
