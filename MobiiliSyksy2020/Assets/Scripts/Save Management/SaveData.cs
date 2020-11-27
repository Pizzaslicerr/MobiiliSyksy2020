//SaveData.cs by Mikko Kyllönen
//contains the save data which is used by the game and written to disk by SaveStreamer.cs.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    private bool isFirstTimePlaying = true;
    public bool IsFirstTimePlaying { get => isFirstTimePlaying;
                                     set => isFirstTimePlaying = value; }

    private LevelData[] levelData = new LevelData[40];
    public LevelData[] LevelData { get => levelData;
                                   set => levelData = value; }

    private int latestCompletedLevel = 0;
    public int LatestCompletedLevel { get => latestCompletedLevel;
                                      set => latestCompletedLevel = value; }

}