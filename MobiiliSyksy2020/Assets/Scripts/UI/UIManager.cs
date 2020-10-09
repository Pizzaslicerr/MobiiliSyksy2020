//UIManager.cs by Mikko Kyllönen
//Manages UI menu navigation.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneTypes
{
    level,
    mapScreen
}

public class UIManager : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject gamePauseMenu = null;
    [SerializeField] private GameObject mapPauseMenu = null;
    [SerializeField] private GameObject pauseButton = null;

    private GameObject currentPauseMenu;
    private bool isPauseMenuOpen = false;

    public SceneTypes SceneType {set => sceneType = value; }
        private SceneTypes sceneType;

    public static UIManager instance;

    void Awake()
    {
        instance = this;
    }

    public void LoadPauseButton()
    {
        pauseButton.SetActive(true);
    }

    //opens either kind of pause menu.
    public void TogglePauseMenu()
    {
        if (!isPauseMenuOpen)
        {
            switch (sceneType)
            {
                case SceneTypes.level:
                    {
                        gamePauseMenu.SetActive(true);
                        isPauseMenuOpen = true;

                        currentPauseMenu = gamePauseMenu;
                        break;
                    }
                case SceneTypes.mapScreen:
                    {
                        mapPauseMenu.SetActive(true);
                        isPauseMenuOpen = true;

                        currentPauseMenu = mapPauseMenu;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        else
        {
            currentPauseMenu.SetActive(false);
            isPauseMenuOpen = false;
        }
    }

    //opens submenus (menus inside menus).
    public void OpenSubmenu(GameObject pauseMenu)
    {
    }

    //closes submenus.
    public void CloseSubmenu(GameObject pauseMenu)
    {
    }
}
