using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextAndReplay : MonoBehaviour
{
    private Scene thisScene;

    private void Awake()
    {
        thisScene = this.gameObject.scene;
    }

    public void nextLevel()
    {
        //Commented the if statement out because Unity is dumb like that and made the statement not work

        /*if (SceneManager.GetSceneByBuildIndex(this.gameObject.scene.buildIndex + 1).IsValid())
        {*/
            SceneHandler.instance.LoadedScene = thisScene;
            SceneHandler.instance.SceneLoad(this.gameObject.scene.buildIndex + 1, thisScene, LoadingScreens.Leaves);
        Time.timeScale = 1; //Unfreezes time
        //}
    }
    public void reloadLevel()
    {
        SceneHandler.instance.SceneReload(this.gameObject.scene.buildIndex, LoadingScreens.Leaves);
        Time.timeScale = 1; //Unfreezes time
    }
}
