using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Collected : MonoBehaviour
{
    public TextMeshProUGUI collected;
    public int numCollect;
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
            
            collected.text = "Collected: " + ++numCollect;
            Destroy(hit.gameObject);
        }
    }

    
}
