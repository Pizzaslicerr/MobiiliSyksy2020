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

    //acts as a pointer so the game knows what array index to save scores to.
    private int currentLevel = 0;
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }

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
