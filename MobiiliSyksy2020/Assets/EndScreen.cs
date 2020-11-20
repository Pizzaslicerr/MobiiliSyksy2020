﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{

    public GameObject Endscrn;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fox")
        {
            Time.timeScale = 0; //Freezes time
            Endscrn.gameObject.SetActive(true);
            GetComponent<AppleHandler>().ApplesAchieved(); //Starts to play ApplesAcheived in AppleHandler
        }
    }
}
