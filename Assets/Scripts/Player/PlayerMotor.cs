using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    public float sprintSpeed = 8f;
    public float walkSpeed = 8f;
    public float speed = 5f;

    public float jumpHeight = 3f;

    private bool isGrounded;
    public float gravity = -9.8f;

    public bool isWalking;
    public bool sprinting;
    public bool crouching;
    public float crouchTimer = 0;
    public bool lerpCrouch;
    
 

    // added in to change animation
    

    public bool isMeleeing = false;
    [SerializeField]
    private float animationFinishTime = 0.9f;
    //

    private Animator animator;

    // Gun
    private WeaponSysem weapon;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        weapon = GetComponentInChildren<WeaponSysem>();

        // Figure out multiple guns later

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }

        }

        // added in to change animation
        if (isMeleeing && animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= animationFinishTime)
        {
            isMeleeing = false;
        }
        //
    }

    // this function will receive input from "InputManager.cs" script and apply to character controller
    public void ProcessMove(Vector2 input)
    {

        Vector3 moveDirection = Vector3.zero;

        // forward backward movement


        moveDirection.x = input.x;
        moveDirection.z = input.y;
        

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        AnimateRun(moveDirection);

        


        // gravity
        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);

    }

    public void FireWeapon()
    {
        Debug.Log("FireWeapon");
        weapon.Shoot();
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            animator.SetTrigger("isJumping");
        }
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting) 
        { 
        speed = sprintSpeed;
        animator.SetBool("isRunning", sprinting);
        } 
        else
        {
            animator.SetBool("isRunning", sprinting);
            speed = walkSpeed;
        }
           
    }

    public void Melee()
    {
        if (!isMeleeing)
        {
            animator.SetTrigger("isMeleeing");
            StartCoroutine(InitialiseMelee());

        }
    }

    IEnumerator InitialiseMelee()
    {
        yield return new WaitForSeconds(0.1f);
        isMeleeing = true;
    }

    public void AnimateRun(Vector3 desiredDirection)
    {
        
        isWalking = (desiredDirection.x > 0.1f || desiredDirection.x < -0.1f || desiredDirection.z > 0.1f || desiredDirection.z < -0.1f) ? true : false;
        animator.SetBool("isWalking", isWalking);
    }
}
