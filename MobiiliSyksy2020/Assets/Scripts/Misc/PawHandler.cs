using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PawHandler : MonoBehaviour
{
    [Tooltip("Essentially player health. Deducted if a bridge is too long or if it falls off.")]
    public int paws;
    private int pawsUsed = 0;

    [SerializeField] private GameObject pawRoot = null;
    [SerializeField] private GameObject pawPrefab = null;
    [SerializeField] private GameObject BridgePrefab = null;
    private GameObject[] UIpaws;


    private void Awake()
    {
        UIpaws = new GameObject[paws];
        SpawnPaws();
    }

    private void SpawnPaws()
    {
        for (int i = 0; i < paws; i++)
        {
            UIpaws[i] = Instantiate(pawPrefab, pawRoot.transform);
        }
    }

    public void pawHandler()
    {
        if (!Bridge.BridgeDown)
        {
            //object cannot be set inactive, otherwise the paw meter will jump all over the place. Instead, the sprite's alpha value is used.
            Color pawSpriteColor = UIpaws[paws - pawsUsed - 1].GetComponent<Image>().color;
            UIpaws[paws - pawsUsed - 1].GetComponent<Image>().color = new Color(pawSpriteColor.r, pawSpriteColor.g, pawSpriteColor.b, 0);

            pawsUsed++;
        }
        if (pawsUsed == UIpaws.Length)
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
        Player.BridgeRB.angularVelocity = 0;
        //Reset the bridge to the next spot, or the current one if it fell
        Player.BridgeO = GameObject.FindWithTag("Bridge");
        Player.BridgeO.transform.localScale = BridgePrefab.transform.localScale;
        Player.BridgeO.transform.rotation = Quaternion.identity;
        Player.BridgeO.transform.position = Player.BridgeSpawnPoint.transform.position;
    }
}
