//Tehnyt: Emilia Leinonen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleHandler : MonoBehaviour
{

    public GameObject[] apples;
    private int pawCount;

    void Start()
    {
        pawCount = GameObject.FindGameObjectsWithTag("Paw").Length;
    }

    public void ApplesAcheived()
    {
        int pawsLeft = GameObject.FindGameObjectsWithTag("Paw").Length;

        //One apple
        if (pawsLeft == 1)
        {
            apples[0].SetActive(true);
    
        }
        //Two apples
        else if (pawsLeft == 2)
        {
            apples[0].SetActive(true);
            apples[2].SetActive(true);
        }
        else if (pawsLeft == 3)
        {
            apples[0].SetActive(true);
            apples[2].SetActive(true);
        }
        //Three apples
        else if (pawsLeft == 4)
        {
            apples[0].SetActive(true);
            apples[2].SetActive(true);
            apples[3].SetActive(true);
        }

    }
}