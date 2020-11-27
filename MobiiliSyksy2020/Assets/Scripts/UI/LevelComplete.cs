using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    public GameObject Endscrn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fox")
        {
            Endscrn.gameObject.SetActive(true);
        }
    }
}
