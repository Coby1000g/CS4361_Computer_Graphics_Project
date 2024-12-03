using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public TextMeshProUGUI Status;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Status.text == "Game Over" || Status.text == "WINNER")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }
}
