using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float bridgeGrowthRate;
    public GameObject Stick;
    public Rigidbody2D StickRB;
    private bool StickGrown;
    // Start is called before the first frame update
    void Start()
    {
        StickRB.simulated = false;
        StickGrown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!StickGrown && Input.GetMouseButton(0))
        {
            Vector3 v = Stick.transform.localScale;
            v.y = v.y + bridgeGrowthRate;
            Stick.transform.localScale = v;
        }
        if (Input.GetMouseButtonUp(0))
        {
            StickRB.simulated = true;
            StickGrown = true;
        }
    }
}
