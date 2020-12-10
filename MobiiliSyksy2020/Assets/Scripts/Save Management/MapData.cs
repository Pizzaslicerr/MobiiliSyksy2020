﻿//MapData.cs by Mikko Kyllönen
//Gets the game save progress and edits the map screen accordingly.
//Also tallies the number of apples collected.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
    public static MapData instance;

    private SaveData data;
    public SaveData Data { get => data;
                           set => data = value; }

    //------------------------------------------------------------------------------------------------------------

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Data = SaveManager.instance.SaveData;
        SetGameProgress();

    }

    //actually inserts the values and game progress into the map screen before anything loads.
    private void SetGameProgress()
    {
        DebugPrintSaveInfo();
    }

    private void DebugPrintSaveInfo()
    {
        for (int i = 0; i < data.LevelData.Length; i++)
        {
            Debug.Log("data.LevelData[" + i + "].AppleScore (LevelNumber = " + (i + 1) + ") = " + data.LevelData[i].AppleScore);
        }
        /*for (int i = 0; i < data.LevelData.Length; i++)
        {
            Debug.Log("data.LevelData[" + i + "].BuildIndex = " + data.LevelData[i].BuildIndex);
        }*/
        Debug.Log("data.LevelData.LatestCompletedLevel = " + data.LatestCompletedLevel);
        //Debug.Log("data.IsFirstTimePlaying = " + data.IsFirstTimePlaying);
    }
}
