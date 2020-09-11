//LoadingScreenManager.cs by Mikko Kyllönen
//Handles different kinds of loading screens.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LOAD_SCREENS
{
    LEAVES = 0,
    LOG = 1,
    WATER_STREAM = 2,
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
    }

    public void Deactivate(int loadScreenVariant)
    {
        loadingScreens[loadScreenVariant].SetActive(false);
    }
}