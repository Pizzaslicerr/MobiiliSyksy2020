//InitializeSceneSwitch.cs by Mikko Kyllönen
//Starts the scene swap/load process.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public class InitializeSceneSwitch : MonoBehaviour
    {
        private bool pauseButtonLoaded = false;

        [SerializeField] private LoadingScreens loadScreenType = LoadingScreens.Leaves;
        [SerializeField] private SceneTypes sceneType = SceneTypes.level;

        [Tooltip("Just drag and drop the desired scene into this field.")]
        [SerializeField] private SceneReference sceneToLoad = null;
        [Tooltip("Whether or not the previous scene should be unloaded. For most cases, leave this enabled.")]
        [SerializeField] private bool unloadPreviousScene = true;

        public void ChangeScenes()
        {
            if (unloadPreviousScene)
            {
                SceneReference currentScene = null;
                currentScene.ScenePath = this.gameObject.scene.path;
                currentScene.OnBeforeSerialize();
                SceneHandler.instance.SceneLoad(sceneToLoad, currentScene, loadScreenType);
            }
            else
            {
                SceneHandler.instance.SceneLoad(sceneToLoad, loadScreenType);
            }

            SceneHandler.instance.LoadedScene = sceneToLoad;
            DetermineSceneType();

            if (!pauseButtonLoaded)
            {
                UIManager.instance.LoadPauseButton();
                pauseButtonLoaded = true;
            }

        }

        //this changes the SceneType variable, which affects what pause menu is used
        private void DetermineSceneType()
        {
            UIManager.instance.SceneType = sceneType;
        }
    }
}
