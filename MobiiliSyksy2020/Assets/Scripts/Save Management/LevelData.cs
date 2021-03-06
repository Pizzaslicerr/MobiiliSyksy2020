﻿//LevelData.cs by Mikko Kyllönen
//Contains all the required information for each level.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    private string levelName = "";
    public string LevelName { get => levelName;
                              set => levelName = value; }

    private int appleScore = 0;
    public int AppleScore { get => appleScore;
                            set => appleScore = value; }
}
