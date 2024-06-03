using System.Collections;
using System.Collections.Generic;
using Platformer.SaveSystem;
using UnityEngine;

public class thirdPersonMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
 
    private float jumpHeight = 3.0f;
    public float turnSmoothTime = 0.1f;
    private Vector3 playerVelocity;
    float TurnSmoothVelocity;
    private Vector3 moveDir;
    private float gravityValue = -15f;

    public Transform groundCheck;

    private float groundDistance = 0.4f;

    private bool groundedPlayer;
    
    public LayerMask groundMask;
 
    // Update is called once per frame
    void Update()
    {
        groundedPlayer = Physics.CheckSphere(groundCheck.position, groundDistance,groundMask);
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
         
        }

        
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        
        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref TurnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);

             moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
             controller.Move(moveDir.normalized * speed * Time.deltaTime);
            
        }

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3f * gravityValue);
        }
         
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
   
}
    
 
 