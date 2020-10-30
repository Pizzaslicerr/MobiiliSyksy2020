using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextAndReplay : MonoBehaviour
{
    public void nextLevel()
    {
        SceneHandler.instance.SceneLoad(this.gameObject.scene.buildIndex + 1, this.gameObject.scene.buildIndex, LoadingScreens.Leaves);
    }
    public void reloadLevel()
    {
        SceneHandler.instance.SceneReload(this.gameObject.scene.buildIndex, LoadingScreens.Leaves);
    }
}
