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
        //Checks how many paws are in the scene
        pawCount = GameObject.FindGameObjectsWithTag("Paw").Length;
   
    }

    public void ApplesAcheived()
    {
        int pawsLost = GameObject.FindGameObjectsWithTag("Paw").Length;

        if (pawsLost == 1)
        {
            //One apple
            apples[0].SetActive(true);
    
        }
        
        else if (pawsLost == 2)
        {
            //Two apples
            apples[0].SetActive(true);
            apples[1].SetActive(true);
        }
        else if (pawsLost == 3)
        {
            //Two apples
            apples[0].SetActive(true);
            apples[1].SetActive(true);
        }

        else if (pawsLost == 4)
        {
            //Three apples
            apples[0].SetActive(true);
            apples[1].SetActive(true);
            apples[2].SetActive(true);
        }

    }
}