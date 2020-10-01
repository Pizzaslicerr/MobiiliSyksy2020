using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    //Making these variables easily accessible from all scripts
    public static bool BridgeGrown;
    public static bool BridgeDown;

    void Start()
    {
        //To make sure a new bridge always has these variables set to false
        BridgeGrown = false;
        BridgeDown = false;
        if (Player.BridgeRB != null)
        {
            Player.BridgeRB.simulated = false;
        }
    }
}