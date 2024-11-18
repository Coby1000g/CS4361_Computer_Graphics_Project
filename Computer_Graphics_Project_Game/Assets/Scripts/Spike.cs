using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public TextMeshProUGUI Status;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Status.text = "Game Over";
            other.gameObject.SetActive(false);
        }
    }

    
    
}
