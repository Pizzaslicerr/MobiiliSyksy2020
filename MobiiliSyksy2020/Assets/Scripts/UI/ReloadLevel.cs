//ReloadLevel.cs by Mikko Kyllönen
//runs the SceneReload() script in SceneHandler.cs by proxy.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    //This is ran through the scene reload button.
    public void Reload()
    {
        if (SceneHandler.instance.LoadedScene.IsValid())
        {
            Time.timeScale = 1; //Unfreezes time
            SceneHandler.instance.SceneReload(SceneHandler.instance.LoadedScene.buildIndex, LoadingScreens.Leaves);
        }
    }
}
