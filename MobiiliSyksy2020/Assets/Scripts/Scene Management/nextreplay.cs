using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextreplay : MonoBehaviour
{
    public void nextLevel()
    {
        SceneManager.LoadScene(this.gameObject.scene.buildIndex + 1);
    }
    public void reloadLevel()
    {
        SceneHandler.instance.SceneReload(this.gameObject.scene.buildIndex, LoadingScreens.Leaves);
    }
}
