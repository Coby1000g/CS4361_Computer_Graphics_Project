using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : MonoBehaviour
{
    float raycast_dist = 5f;
    CharacterController characterController;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            RaycastHit stomp;
            if (Physics.Raycast(transform.position, Vector3.down, out stomp, raycast_dist))
            {
                Debug.Log("Enemy detected, destroying...");
                Destroy(hit.gameObject); 
                characterController.Move(Vector3.up * 200f * Time.deltaTime);
            }
            
           
            
        }
            
    }
}
