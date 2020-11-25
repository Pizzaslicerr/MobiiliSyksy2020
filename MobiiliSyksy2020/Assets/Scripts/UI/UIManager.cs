//UIManager.cs by Mikko Kyllönen
//Manages UI menu navigation.
//Modified by Emilia Leinonen. Added animation stuff.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneTypes
{
    level,
    mainMenu,
    mapScreen
}

public class UIManager : MonoBehaviour
{
    [Tooltip("This is the canvas that contains all the menus and submenus.")]
    [SerializeField] private GameObject pauseMenuObjects = null;

    [Header("Menus")]
    [SerializeField] private GameObject gamePauseMenu = null;
    [SerializeField] private GameObject mapPauseMenu = null;
    [SerializeField] private GameObject pauseButton = null;

    private GameObject currentPauseMenu;
    private bool isPauseMenuOpen = false;
    private bool isCanvasVisible = true;

    public SceneTypes SceneType {set => sceneType = value; }
        private SceneTypes sceneType = SceneTypes.mainMenu;

    public static UIManager instance;

    public Animator UIanim;
    public bool isDown = false;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentPauseMenu = mapPauseMenu;
        UIanim = gameObject.GetComponent<Animator>();
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

                        isDown = true;
                        Time.timeScale = 0; //Freezes time

                        currentPauseMenu = gamePauseMenu;
                        break;
                    }
                case SceneTypes.mapScreen:
                    {
                        mapPauseMenu.SetActive(true);
                        isPauseMenuOpen = true;

                        isDown = true;
                        Time.timeScale = 0; //Freezes time

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
            Time.timeScale = 1; //Unfreezes time
        }
    }

    //This hides the pause button (and menus) for loading screens.
    public void ToggleCanvas()
    {
        if (isCanvasVisible)
        {
            HidePauseMenu();
            pauseMenuObjects.SetActive(false);
            isPauseMenuOpen = false;
        }
        else
        {
            pauseMenuObjects.SetActive(true);
        }

        isCanvasVisible = !isCanvasVisible;
    }

    //This only hides the actual overlay, not the button.
    public void HidePauseMenu()
    {
        currentPauseMenu.SetActive(false);
        isDown = false;
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
