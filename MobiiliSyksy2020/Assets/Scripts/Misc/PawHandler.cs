using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PawHandler : MonoBehaviour
{
    public static PawHandler instance;

    [Tooltip("Essentially player health. Deducted if a bridge is too long or if it falls off.")]
    public int paws = 4;
    [HideInInspector] public int pawsUsed = 0;

    [Header("Sprites")]
    [SerializeField] private Sprite[] unspentPawSprites = new Sprite[4];
    [SerializeField] private Sprite[] spentPawSprites = new Sprite[4];

    [Header("Prefabs")]
    [SerializeField] private GameObject pawPrefab = null;
    [SerializeField] private GameObject pawRoot = null;
    [SerializeField] private GameObject BridgePrefab = null;

    [SerializeField] private GameObject[] UIPaws;


    private void Awake()
    {
        instance = this;
        UIPaws = new GameObject[paws];

        SpawnPaws();
    }

    private void SpawnPaws()
    {
        for (int i = 0; i < paws; i++)
        {
            UIPaws[i] = Instantiate(pawPrefab, pawRoot.transform);

            UIPaws[i].GetComponent<Image>().sprite = unspentPawSprites[i];
        }
    }

    public void pawHandler()
    {
        if (!Bridge.BridgeDown)
        {
            //Changes the specific paw sprite to its spent counterpart
            UIPaws[paws - pawsUsed - 1].GetComponent<Image>().sprite = spentPawSprites[paws - pawsUsed - 1];
            pawsUsed++;
        }
        if (pawsUsed == UIPaws.Length)
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
