//SaveManager.cs by Mikko Kyllönen
//Calls for game saving and loading when necessary.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    private void Awake()
    {
        instance = this;
    }

    public SaveData saveData = new SaveData();

    public void SaveGame()
    {
        SaveStreamer.SaveGame(saveData);
    }

    public void LoadSave()
    {
        SaveStreamer.LoadSave();
    }
}
