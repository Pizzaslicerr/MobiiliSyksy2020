//ReloadLevel.cs by Mikko Kyllönen
//runs the SceneReload() script in SceneHandler.cs by proxy.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    public void Reload()
    {
        SceneHandler.instance.SceneReload(SceneHandler.instance.LoadedScene, LoadingScreens.Leaves);
    }
}
