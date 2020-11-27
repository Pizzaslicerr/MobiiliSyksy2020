using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{

    public GameObject Endscrn;
    public Animator UIanim;
    public bool isDown = false;

    private void Start()
    {
        UIanim = gameObject.GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fox")
        {
            Time.timeScale = 0; //Freezes time
            isDown = true;
            Endscrn.gameObject.SetActive(true);
            if (SaveManager.instance.SaveData.LatestCompletedLevel < SaveManager.instance.CurrentLevel)
            {
                SaveManager.instance.SaveData.LatestCompletedLevel = SaveManager.instance.CurrentLevel;
            }
            GetComponent<AppleHandler>().ApplesAchieved(); //Starts to play ApplesAcheived in AppleHandler
        }
    }
}
