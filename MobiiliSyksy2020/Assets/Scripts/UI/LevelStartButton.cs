//LevelStartButton.cs by Mikko Kyllönen
//Activates the level load script in the parent.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class LevelStartButton : MonoBehaviour
{
    private InitializeSceneSwitch init;

    private void Awake()
    {
        init = GetComponentInParent<InitializeSceneSwitch>();
    }

    public void PressLevelLoadButton()
    {
        init.ChangeScenes();
    }
}
