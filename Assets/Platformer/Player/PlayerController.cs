using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rigidbody;
    private Vector3 _movementInput;
    
    private bool isOnGround;
    private bool _canJump;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandeMovement();
        HandleJump();
        HandleMouseRotation();
    }

    private void HandleMouseRotation()
    {
       
    }

    private void FixedUpdate()
    {
        //move player
        _rigidbody.MovePosition(transform.position + _movementInput * 5 * Time.fixedDeltaTime);
        
         Jump();
    }
    
    void HandleJump()
    {
        isOnGround = Physics.Raycast(transform.position, -Vector3.up,  0.5f);
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            _canJump = true;
        }

    }
    void Jump()
    {
        
        if (_canJump)
        {
            _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
            _canJump = false;
        }
    }

    void HandeMovement()
    {
        _movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (_movementInput.magnitude > 1)
        {
            _movementInput.Normalize();
        }
    }
          
 
}
