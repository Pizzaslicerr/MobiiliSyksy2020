//LevelIndexTracker.cs by Mikko Kyllönen
//Called whenever a level is loaded, so MapData.cs knows what to change.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIndexTracker : MonoBehaviour
{
    [SerializeField] private int levelIndex = 0;

    //sets index to a specific value; used by map screen.
    public void SetLevelIndex()
    {
        SaveManager.instance.LevelIndex = levelIndex;
    }

    //increments index by 1; used by levels' "next level" button.
    public void IncrementLevelIndex()
    {
        SaveManager.instance.LevelIndex++;
    }
}
