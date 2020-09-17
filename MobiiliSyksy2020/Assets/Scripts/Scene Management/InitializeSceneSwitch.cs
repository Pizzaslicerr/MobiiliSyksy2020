using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeSceneSwitch : MonoBehaviour
{
    [SerializeField] private LoadingScreens loadScreenType = LoadingScreens.Leaves;
    public void ChangeScenes(int sceneToLoad)
    {
        SceneHandler.instance.SceneLoad(sceneToLoad, this.gameObject.scene.buildIndex, loadScreenType);
    }
}
