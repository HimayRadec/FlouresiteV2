using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;

    // Start is called before the first frame update
    void Awake()
    {
        // Makes the cursor disappear and lock on screen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        onFoot = playerInput.OnFoot;
        playerInput = new PlayerInput();
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        // When the button is pressed it will call this function from the PlayerMotor script

        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.Sprint.performed += ctx => motor.Sprint();
        onFoot.Melee.performed += ctx => motor.Melee();
        onFoot.Shooting.performed += ctx => motor.FireWeapon();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // move using the value from our movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
