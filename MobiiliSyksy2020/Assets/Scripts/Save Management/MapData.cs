//MapData.cs by Mikko Kyllönen
//Gets the game save progress and edits the map screen accordingly.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
    public static MapData instance;

    private SaveData data;
    public SaveData Data { get => data;
                           set => data = value; }

    private void Awake()
    {
        instance = this;
        Data = SaveStreamer.LoadSave();
        SetGameProgress();
    }

    //actually inserts the values and game progress into the map screen before anything loads.
    private void SetGameProgress()
    {
        SaveData testsavedata = data;
        LevelData[] testleveldata = data.LevelData;

        //debug
        for (int i = 0; i < data.LevelData.Length; i++)
        {
            data.LevelData[i].AppleScore = Random.Range(0, 4);
            Debug.Log("data.LevelData[" + i + "].AppleScore. =" + data.LevelData[i].AppleScore);
        }
    }
}
