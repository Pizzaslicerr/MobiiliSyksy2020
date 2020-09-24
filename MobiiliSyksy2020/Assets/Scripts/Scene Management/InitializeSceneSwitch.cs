using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public class InitializeSceneSwitch : MonoBehaviour
    {
        [SerializeField] private LoadingScreens loadScreenType = LoadingScreens.Leaves;
        [SerializeField] private SceneField sceneToLoad;
        [Tooltip("Whether or not the previous scene should be unloaded. For most cases, leave this enabled.")]
        [SerializeField] private bool unloadPreviousScene = true;

        public void ChangeScenes()
        {
            if (unloadPreviousScene)
            {
                SceneHandler.instance.SceneLoad(sceneToLoad, this.gameObject.scene.buildIndex, loadScreenType);
            }
            else
            {
                SceneHandler.instance.SceneLoad(sceneToLoad, loadScreenType);
            }
        }
    }
}
