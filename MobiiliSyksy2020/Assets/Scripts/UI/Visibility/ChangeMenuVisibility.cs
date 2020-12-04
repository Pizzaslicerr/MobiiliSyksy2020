//ChangeMenuVisibility.cs by Mikko Kyllönen
//Shows and/or hides specified UI elements.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMenuVisibility : MonoBehaviour
{
    public void ShowUIElement(GameObject element)
    {
        element.SetActive(true);
    }

    public void HideUIElement(GameObject element)
    {
        element.SetActive(false);
    }
}
