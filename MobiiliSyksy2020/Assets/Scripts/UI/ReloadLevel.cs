//ReloadLevel.cs by Mikko Kyllönen
//runs the SceneReload() script in SceneHandler.cs by proxy.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    private Scene sceneToReload = SceneManager.GetSceneByPath(SceneHandler.instance.LoadedScene);
    public void Reload()
    {
        if (sceneToReload.IsValid())
        {
            SceneHandler.instance.SceneReload(sceneToReload.buildIndex, LoadingScreens.Leaves);
        }
    }
}
