//LockMapButtons.cs by Mikko Kyllönen
//Hides the level buttons that have not been unlocked yet when map screen loads.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class LockMapButtons : MonoBehaviour
    {
        private InitializeSceneSwitch init;

        private void Start()
        {
            init = GetComponent<InitializeSceneSwitch>();

            if (init.LevelNumber - 1 > SaveManager.instance.SaveData.LatestCompletedLevel)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
