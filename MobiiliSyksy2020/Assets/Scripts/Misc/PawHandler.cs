using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawHandler : MonoBehaviour
{
    public GameObject[] paw;

    [SerializeField] private int pawsUsed;

    [SerializeField] private GameObject BridgePrefab = null;

    public void pawHandler()
    {
        if (!Bridge.BridgeDown)
        {
            Debug.Log("pawsUsed: " + pawsUsed);
            paw[pawsUsed].SetActive(false);
            pawsUsed++;
        }
        if (pawsUsed == paw.Length)
        {
            SceneHandler.instance.SceneReload(this.gameObject.scene.buildIndex, LoadingScreens.Leaves);
        }
    }
    public void BridgeReset()
    {
        pawHandler();
        //Find the current active spawn point for the bridge
        Player.BridgeSpawnPoint = GameObject.FindWithTag("BridgeSpawnPoint");
        //Reset variables and remove bridge constraints
        Bridge.BridgeGrown = false;
        Player.BridgeRB.simulated = false;
        Bridge.BridgeDown = false;
        Player.BridgeRB.freezeRotation = false;
        Player.BridgeRB.constraints = RigidbodyConstraints2D.None;
        //Reset the bridge to the next spot, or the current one if it fell
        Player.BridgeO = GameObject.FindWithTag("Bridge");
        Player.BridgeO.transform.localScale = BridgePrefab.transform.localScale;
        Player.BridgeO.transform.rotation = BridgePrefab.transform.rotation;
        Player.BridgeO.transform.position = Player.BridgeSpawnPoint.transform.position;
    }
}
