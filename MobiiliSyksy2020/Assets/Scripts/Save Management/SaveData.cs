//SaveData.cs by Mikko Kyllönen
//contains the save data which is used by the game and written to disk by SaveStreamer.cs.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    private int latestCompletedLevel = 0;
    public int LatestCompletedLevel { get => latestCompletedLevel;
                                      set => latestCompletedLevel = value; }

    //levels should only have values between 0 and 3.
    private int[] levelApples = new int[40];
    public int[] LevelApples { get => levelApples; set => levelApples = value; }
}