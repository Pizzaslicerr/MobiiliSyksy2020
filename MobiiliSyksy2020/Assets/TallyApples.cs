using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMPro
{
    public class TallyApples : MonoBehaviour
    {
        [SerializeField] private TMP_Text TMPText;
        private LevelData[] levelData = new LevelData[40];

        private int talliedApples;
        private int totalApples;

        private void Start()
        {
            levelData = SaveManager.instance.SaveData.LevelData;

            for (int i = 0; i < levelData.Length; i++)
            {
                talliedApples += levelData[i].AppleScore;
                totalApples += 3;
            }

            TMPText.text = talliedApples + "/" + totalApples;
        }
    }
}
