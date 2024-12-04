using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Collected : MonoBehaviour
{
    public TextMeshProUGUI collected;
    public TextMeshProUGUI Status;
    public int numCollect;
    public Boolean looting = false;
    // Start is called before the first frame update
    void Start()
    {
        numCollect = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Collectible"))
        {
            looting = true;
            Collider collider = hit.gameObject.GetComponent<Collider>();
            if (collider != null) collider.enabled = false; Destroy(hit.gameObject);
            if (looting)
            {
                looting = false;
                numCollect = numCollect + 1;
            }
            collected.text = "Collected: " + numCollect;
            looting = false;
            if (numCollect == 4)
            {
                Status.text = "WINNER";
            }
        }
    }

    
}
