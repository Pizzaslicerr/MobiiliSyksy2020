//LevelStatPopup.cs by Mikko Kyllönen
//instantiates the level info window upon clicking a level button.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStatPopup : MonoBehaviour
{
    [Tooltip("This value determines how early the popup panel will start compensating for the screen's edge.")]
    [Range(0f, 500f)]
    public int edgeTreshold = 0;

    private GameObject previousLevelButton = null;      //these are all marked as null to remove warning messages from log. They don't affect anything.
    private GameObject levelPopup = null;

    [SerializeField] private GameObject popupPanelPrefab = null;
    [SerializeField] private GameObject popupArrowPrefab = null;

    private int appleCount = 0;
    public int AppleCount { get => appleCount;
                            set => appleCount = value; }

    public void ToggleLevelStats(GameObject currentButton)
    {
        //does a popup not yet exist in the scene?
        if (levelPopup == null)
        {
            //instantiates the arrow as the level button's child, and the info panel as the arrow's child
            InstantiatePopup(currentButton);
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
                InstantiatePopup(currentButton);
            }
        }

        previousLevelButton = currentButton;
    }

    //instantiates the popup and offsets it from the edge of the screen if it is too close.
    private void InstantiatePopup(GameObject currentButton)
    {
        var buttonPositionX = currentButton.GetComponent<RectTransform>().localPosition.x;

        levelPopup = Instantiate(popupArrowPrefab, currentButton.transform.position, popupArrowPrefab.transform.rotation, currentButton.transform);
        var popupPanel = Instantiate(popupPanelPrefab, levelPopup.transform);

        if (Mathf.Abs(buttonPositionX) > edgeTreshold)
        {
            //This equation offsets the position of the popup panel if it is too close to the edge of the screen.
            popupPanel.transform.position = new Vector3(popupPanel.transform.position.x + ((Mathf.Sign(buttonPositionX) * (Mathf.Abs(buttonPositionX) - edgeTreshold)) * -1) / 2,
                                                        popupPanel.transform.position.y,
                                                        0);
        }
    }
}
