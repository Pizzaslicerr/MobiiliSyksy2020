//LevelStatPopup.cs by Mikko Kyllönen
//instantiates the level info window upon clicking a level button.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStatPopup : MonoBehaviour
{
    private GameObject previousLevelButton = null;
    private GameObject levelPopup = null;
    [SerializeField] private GameObject popupPrefab;

    public void ToggleLevelStats(GameObject currentButton)
    {
        //does a popup already exist in the scene?
        if (levelPopup == null)
        {
            levelPopup = Instantiate(popupPrefab, currentButton.transform.position, popupPrefab.transform.rotation, currentButton.transform);
        }

        else if (previousLevelButton != null)
        {
            //is the clicked button the same as the previously clicked button?
            if (currentButton == previousLevelButton)
            {
                Destroy(levelPopup);
            }

            //destroy old popup and create a new one
            else
            {
                Destroy(levelPopup);
                levelPopup = Instantiate(popupPrefab, currentButton.transform.position, popupPrefab.transform.rotation, currentButton.transform);
            }
        }

        previousLevelButton = currentButton;
    }
}
