using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.8f;
    public Transform groundCheck;
    float radius = 0.4f;
    public LayerMask ground;
    bool isGrounded;

    

    Vector3 velocity;

    

    private void Update()
    {

        float x = joystick.Horizontal;
        float z = joystick.Vertical;
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, radius, ground);
        if (isGrounded)
        {
            velocity.y = 0f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
            
        }

        


    }
    void Jump()
    {
        if (isGrounded)
        {
            velocity.y = 11f;
            controller.Move(velocity * Time.deltaTime);
        }
        
    }


}
