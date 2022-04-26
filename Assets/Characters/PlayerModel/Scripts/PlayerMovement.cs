using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    //VARIABLES
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    // private Vector3 velocity;

    // [SerializeField] private bool isGrounded;
    // [SerializeField] private float groundCheckDistance;
    // [SerializeField] private LayerMask groundMask;
    // [SerializeField] private float gravity;

    // [SerializeField] private float jumpHeight;



    //REFERENCES
    private CharacterController controller;
    private Animator anim;

    private void Start() {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        Move();

    }

    private void Move() {
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        
        
        if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)){
            Walk();
        }
        else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) {
            Run();
        }
        else if(moveDirection == Vector3.zero) {
            Idle();
        }
            
        moveDirection *= moveSpeed;

        controller.Move(moveDirection * Time.deltaTime);

    }

    private void Idle() {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk() {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    

    private void Run() {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

   



}
