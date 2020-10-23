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

        [SerializeField] private SceneField sceneToLoad = null;
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

            SceneHandler.instance.LoadedScene = sceneToLoad.SceneName;
            DetermineSceneType();

            if (!pauseButtonLoaded)
            {
                UIManager.instance.LoadPauseButton();
                pauseButtonLoaded = true;
            }

        }

        //only used to switch to map scene
        public void ChangeToMapScene(int mapBuildIndex)
        {
            SceneHandler.instance.SceneLoad(mapBuildIndex, SceneHandler.instance.LoadedScene, loadScreenType);
            DetermineSceneType();
        }

        //this changes the SceneType variable, which affects what pause menu is used
        private void DetermineSceneType()
        {
            UIManager.instance.SceneType = sceneType;
        }
    }
}
