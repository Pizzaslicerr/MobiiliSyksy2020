//SceneHandler.cs by Mikko Kyllönen
//This script manages scene switching and loading screens.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private LoadingScreenManager loadingScreenManager;  //loading screens are only visible (for now) with LoadAndUnloadScene()
    public GameObject backupCamera;
    private string loadedScene;
    public string LoadedScene { get => loadedScene; set => loadedScene = value; }


    public static SceneHandler instance;
    private void Awake()
    {
        instance = this;    //public singleton, so easily accessible
        loadingScreenManager = gameObject.GetComponent<LoadingScreenManager>();
    }

    //scene load operations are added to this list; this is required for loading bars and especially to make sure scenes have been loaded
    //two voids for method overloads, having a scene to unload is not necessary
    List<AsyncOperation> operations = new List<AsyncOperation>();
    public void SceneLoad(SceneField sceneToLoad, LoadingScreens loadingScreen)
    {
        backupCamera.SetActive(true);
        operations.Add(SceneManager.LoadSceneAsync(sceneToLoad.SceneName, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress());
    }


    //an alternative version of SceneLoad where the previous scene is unloaded during the new scene's load process. This is the one that's most often used.
    public void SceneLoad(SceneField sceneToLoad, int sceneToUnload, LoadingScreens loadingScreen)
    {
        ToggleVisibilities(loadingScreen);
        operations.Add(SceneManager.UnloadSceneAsync(sceneToUnload));
        operations.Add(SceneManager.LoadSceneAsync(sceneToLoad.SceneName, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress((int)loadingScreen));
    }


    //This is only used for the map screen. Goddamn edgecases...
    public void SceneLoad(int mapBuildIndex, string sceneToUnload, LoadingScreens loadingScreen)
    {
        ToggleVisibilities(loadingScreen);
        operations.Add(SceneManager.UnloadSceneAsync(sceneToUnload));
        operations.Add(SceneManager.LoadSceneAsync(mapBuildIndex, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress((int)loadingScreen));
    }

    //reloads current scene, so only requires one scene.
    public void SceneReload(int sceneToReload, LoadingScreens loadingScreen)
    {
        ToggleVisibilities(loadingScreen);
        operations.Add(SceneManager.UnloadSceneAsync(sceneToReload));
        operations.Add(SceneManager.LoadSceneAsync(sceneToReload, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress((int)loadingScreen));
    }


    private IEnumerator GetSceneLoadProgress()
    {
        for (int i = 0; i < operations.Count; i++)
        {
            while (!operations[i].isDone)   //runs until the scene the AsyncOperation list is handling has loaded, then moves on to the next
            {
                yield return null;
            }
        }

        UIManager.instance.ToggleCanvas();
        backupCamera.SetActive(false);
        operations.Clear();
        yield break;
    }

    private IEnumerator GetSceneLoadProgress(int loadScreenVariant)
    {
        for (int i = 0; i < operations.Count; i++)
        {
            while (!operations[i].isDone)
            {
                yield return null;
            }
        }
        yield return new WaitForSecondsRealtime(1f);

        UIManager.instance.ToggleCanvas();
        backupCamera.SetActive(false);
        loadingScreenManager.Deactivate(loadScreenVariant);
        operations.Clear();
        yield break;
    }

    private void ToggleVisibilities(LoadingScreens loadingScreen)
    {
        backupCamera.SetActive(true);
        UIManager.instance.ToggleCanvas();
        loadingScreenManager.Activate((int)loadingScreen);
    }
}
