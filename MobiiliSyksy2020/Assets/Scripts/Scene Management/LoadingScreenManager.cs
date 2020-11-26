//LoadingScreenManager.cs by Mikko Kyllönen
//Handles different kinds of loading screens.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LoadingScreens
{
    Leaves = 0,
    Log = 1,
    WaterStream = 2,
}

public class LoadingScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject[] loadingScreens = new GameObject[0];

    private static LoadingScreenManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void Activate(int loadScreenVariant)
    {
        loadingScreens[loadScreenVariant].SetActive(true);
        Time.timeScale = 0; //Freezes time
    }

    public void Deactivate(int loadScreenVariant)
    {
        loadingScreens[loadScreenVariant].SetActive(false);
        Time.timeScale = 1; //Unfreezes time
    }
}