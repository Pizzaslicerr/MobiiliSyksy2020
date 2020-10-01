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
    private int loadedScene;
    public int LoadedScene { set => loadedScene = value; }


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


    public void SceneLoad(SceneField sceneToLoad, int sceneToUnload, LoadingScreens loadingScreen)
    {
        backupCamera.SetActive(true);
        loadingScreenManager.Activate((int)loadingScreen);
        operations.Add(SceneManager.LoadSceneAsync(sceneToLoad.SceneName, LoadSceneMode.Additive));
        operations.Add(SceneManager.UnloadSceneAsync(sceneToUnload));

        StartCoroutine(GetSceneLoadProgress((int)loadingScreen));
    }

    public void SceneReload(int sceneToReload, LoadingScreens loadingScreen)
    {
        backupCamera.SetActive(true);
        loadingScreenManager.Activate((int)loadingScreen);
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

        backupCamera.SetActive(true);
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

        backupCamera.SetActive(false);
        loadingScreenManager.Deactivate(loadScreenVariant);
        operations.Clear();
        yield break;
    }
}
