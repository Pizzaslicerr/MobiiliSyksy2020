//PersistenceCheck.cs by Mikko Kyllönen
//Include this script once in every scene! This makes sure the scene manager scene is loaded every time, even if the SceneManager scene itself is not loaded first.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistenceCheck : MonoBehaviour
{
    private List<AsyncOperation> operations = new List<AsyncOperation>();
    private bool isSceneLoading = false;

    private void Awake()
    {
        //loads SceneManager if it has not yet been loaded
        if (SceneManager.sceneCount == 1)
        {
            if (SceneManager.GetSceneAt(0).buildIndex == 0)
            {
                Debug.Log("This should only run once");
                operations.Add(SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive));
            }
            else
            {
                Debug.Log("This should only run once");
                operations.Add(SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive));
            }
            StartCoroutine(LoadPersistentScene());
        }
        StartCoroutine(ChangeLoadedSceneReference());

        Time.timeScale = 1; //Unfreezes time
    }

    //This makes sure all required scenes are loaded
    private IEnumerator LoadPersistentScene()
    {
        isSceneLoading = true;

        for (int i = 0; i < operations.Count; i++)
        {
            while (!operations[i].isDone)
            {
                yield return null;
            }
        }
        operations.Clear();
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));

        isSceneLoading = false;
        yield break;
    }

    //This changes the LoadedScene values in SceneHandler whenever a new scene has been loaded.
    private IEnumerator ChangeLoadedSceneReference()
    {
        while (isSceneLoading)
        {
            yield return null;
        }

        //makes it so the most recently loaded scene (that isn't for managing game elements) is easily accessible
        if (this.gameObject.scene.buildIndex != 0)
        {
            SceneHandler.instance.LoadedScene = this.gameObject.scene;
            SceneHandler.instance.LoadedSceneIndex = this.gameObject.scene.buildIndex;

            Debug.Log("LoadedSceneIndex = " + SceneHandler.instance.LoadedSceneIndex);
        }

        yield break;
    }
}
