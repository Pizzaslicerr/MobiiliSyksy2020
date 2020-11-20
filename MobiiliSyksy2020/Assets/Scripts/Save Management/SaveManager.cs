//SaveManager.cs by Mikko Kyllönen
//Calls for game saving and loading when necessary.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private SaveData saveData = new SaveData();
    public SaveData SaveData { get => saveData;
                               set => saveData = value; }

    private int levelIndex = 0;
    public int LevelIndex { get => levelIndex;
                            set => levelIndex = value; }


    private void Awake()
    {
        instance = this;
        LoadSave();
    }

    public void SaveGame()
    {
        SaveStreamer.SaveGame(SaveData);
    }

    public void LoadSave()
    {
        SaveData = SaveStreamer.LoadSave();
    }
}
