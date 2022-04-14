using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Reference to use CharacterController in order to move, drag and drop please.
    public CharacterController controller;

    public float speed = 8f;
    public float gravity = -6.81f;
    public float jumpHeight = 3f;

    // Creating reference for the Object created "Grounded" obj.
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    // Velocity is storing our current velocity.
    Vector3 velocity;
    bool isGrounded;

    void FixedUpdate()
    {
        //---------------------- GROUNDED/GRAVITY PT1 ----------------------
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //---------------------------- MOVEMENT ----------------------------

        // Getting the preset inputs and assigning them variables; x & y.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Transform.Right takes the direction of the player is facing (important to reset beforhand)
        // Samething with Transform.forward, taking player direction and going foward.
        Vector3 move = transform.right * x + transform.forward * z;

        // Using method Move to take in all the motion to move with a set speed.
        controller.Move(move * speed * Time.deltaTime);

        //---------------------- GROUNDED/GRAVITY PT2 ----------------------

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        // Move based on our velocity, free fall
        controller.Move(velocity * Time.deltaTime);
    }
}
