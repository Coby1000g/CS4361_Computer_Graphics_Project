using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player_controller : MonoBehaviour
{
    public float raycast_dist = 5f;
    public float horizontalInput;
    public float verticalInput;
    public float maxSpeed = 5.0f;
    public float speed = 0f;
    public float acceleration = .04f;
    public float deacceleration = .05f;
    public float vertical_velocity;
    public float gravity = -9.8f;
    public float gravity_multiplier = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public CharacterController controller;
    public Transform cam;

    private Vector3 moveDirection;
    public Vector3 platformMovement;
    public Vector3 previousPlatPos;
    public bool onPlat;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (speed < 0f)
            speed = 0f;
        if (speed < maxSpeed && (horizontalInput != 0f || verticalInput != 0f))
            speed += acceleration;
        if (horizontalInput == 0f && verticalInput == 0f && speed > 0)
            speed -= deacceleration;

        
        
        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        ApplyGravity();
        //transform.Translate(Vector3.down * vertical_velocity);

        moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            vertical_velocity = 15;
        }
        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 newMoveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        
         controller.Move(newMoveDirection.normalized * speed + new Vector3(0, vertical_velocity, 0) * Time.deltaTime);
  
    }

    
    public void ApplyGravity()
    {
        vertical_velocity += gravity * gravity_multiplier * Time.deltaTime;
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
                vertical_velocity = 5f;
                //controller.Move(Vector3.up * 200f * Time.deltaTime);
            }

        }

       
            if (hit.gameObject.CompareTag("Platform"))
            {
                transform.parent = hit.transform;
            }
            else
            {
                transform.parent = null;
            }

    }

    
}
