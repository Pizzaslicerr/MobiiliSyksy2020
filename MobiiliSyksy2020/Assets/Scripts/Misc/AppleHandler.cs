//Tehnyt: Emilia Leinonen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleHandler : MonoBehaviour
{
    public GameObject[] apples;

    //Plays when Endscreen pops up
    public void ApplesAchieved()
    {
        int pawsUsed = PawHandler.instance.pawsUsed;
        var currentLevel = SaveManager.instance.CurrentLevel;

        switch (pawsUsed)
        {
            //Three apples
            case 0:
                foreach (GameObject apple in apples)
                {
                    if (SaveManager.instance.SaveData.LevelData[currentLevel].AppleScore < 3)
                    {
                        SaveManager.instance.SaveData.LevelData[currentLevel].AppleScore = 3;
                        SaveManager.instance.SaveGame();
                    }
                    apple.SetActive(true);
                }
                break;

            //Two apples
            case 1:
                if (SaveManager.instance.SaveData.LevelData[currentLevel].AppleScore < 2)
                {
                    SaveManager.instance.SaveData.LevelData[currentLevel].AppleScore = 2;
                    SaveManager.instance.SaveGame();
                }

                apples[0].SetActive(true);
                apples[1].SetActive(true);
                break;

            //One apple, two cases
            case 2:
            case 3:
                if (SaveManager.instance.SaveData.LevelData[currentLevel].AppleScore < 1)
                {
                    SaveManager.instance.SaveData.LevelData[currentLevel].AppleScore = 1;
                    SaveManager.instance.SaveGame();
                }

                apples[0].SetActive(true);
                break;

            //This shouldn't activate
            default:
                Debug.LogError("Too many paws lost ( " + pawsUsed + " ), yet player won anyway!");
                break;
        }
    }
}