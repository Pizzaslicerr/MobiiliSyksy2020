//PersistenceCheck.cs by Mikko Kyllönen
//Include this script once in every scene! This makes sure the scene manager scene is loaded every time, even if the SceneManager scene itself is not loaded first.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistenceCheck : MonoBehaviour
{
#if UNITY_EDITOR

    List<AsyncOperation> operations = new List<AsyncOperation>();
    private void Awake()
    {
        if (SceneManager.GetSceneByBuildIndex(0).isLoaded == false)
        {
            Debug.Log("This should run only once");
            operations.Add(SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive));
            StartCoroutine(LoadPersistentScene());
        }
    }

    //This makes sure all required scenes are loaded
    private IEnumerator LoadPersistentScene()
    {
        for (int i = 0; i < operations.Count; i++)
        {
            while (!operations[i].isDone)
            {
                yield return null;
            }
        }
        operations.Clear();
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));

        yield break;
    }

#endif
}
