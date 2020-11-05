using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextAndReplay : MonoBehaviour
{
    [SerializeField] SceneReference thisScene = null;
    private void Awake()
    {
        thisScene.ScenePath = this.gameObject.scene.path;
        thisScene.OnBeforeSerialize();
    }

    public void nextLevel()
    {
        if (SceneManager.GetSceneByBuildIndex(this.gameObject.scene.buildIndex + 1).IsValid())
        {
            SceneHandler.instance.LoadedScene = thisScene;
            SceneHandler.instance.SceneLoad(this.gameObject.scene.buildIndex + 1, thisScene, LoadingScreens.Leaves);
        }
    }
    public void reloadLevel()
    {
        SceneHandler.instance.SceneReload(this.gameObject.scene.buildIndex, LoadingScreens.Leaves);
    }
}
