//InitializeSceneSwitch.cs by Mikko Kyllönen
//Starts the scene swap/load process.
//Additionally starts levels specified in the level select.

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
                SceneHandler.instance.SceneLoad(sceneToLoad, SceneHandler.instance.LoadedScene, loadScreenType);
            }
            else
            {
                SceneHandler.instance.SceneLoad(sceneToLoad, loadScreenType);
            }

            UniversalSanityChecks();
        }

        [Header("Only used in Level Select")]
        [Tooltip("Leave this at 0 in any other scene.")]
        [SerializeField] private int levelNumber = 0;
        public int LevelNumber { get => levelNumber; }

        //Only used in map screen. Loads the level number that's specified.
        public void StartIndexedLevel()
        {
            if (LevelNumber > 0)
            {
                SaveManager.instance.CurrentLevel = LevelNumber;
                SceneHandler.instance.SceneLoad(sceneToLoad, SceneHandler.instance.LoadedScene, loadScreenType);
            }
            else
            {
                Debug.LogError("Level number too low!");
            }

            UniversalSanityChecks();
        }

        //These are strings which all of the different types of functions above should run.
        private void UniversalSanityChecks()
        {
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
