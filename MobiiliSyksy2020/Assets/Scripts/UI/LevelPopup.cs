//LevelStartButton.cs by Mikko Kyllönen
//Activates the level load script in the parent.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class LevelPopup : MonoBehaviour
{
    private InitializeSceneSwitch init;

    private int appleCount;
    [SerializeField] private GameObject[] apples = new GameObject[3];


    private void Awake()
    {
        init = GetComponentInParent<InitializeSceneSwitch>();
    }

    private void Start()
    {
        Debug.LogError("Warning Mikko that this still needs to be fixed tomorrow");
        //Gets the apple count of the level corresponding to the sibling index.
        appleCount = MapData.instance.Data.LevelApples[transform.parent.transform.GetSiblingIndex()];
        for (int i = 0; i < appleCount; i++)
        {
            apples[i].SetActive(true);
        }
    }

    public void PressLevelLoadButton()
    {
        init.ChangeScenes();
    }
}
