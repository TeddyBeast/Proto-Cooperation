﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputMovement : MonoBehaviour
{
    PlayerControls controls;

    public Transform groundCheck;

    public LayerMask groundMask;

    Rigidbody rb;

    Vector3 InitScale;
    Vector3 velocity;

    public int indexPlayer = 0;

    public float speed = 7f;
    public float groundDistance = 1f;
    public float JumpHeight = 7f;
    public float gravity = -9.81f;

    public bool isGrounded;

    float moveHorizontal;
    float moveVertical;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<Transform>();
        velocity = rb.velocity;

        InitScale = transform.localScale;
    }

    private void Awake()
    {
        controls = new PlayerControls();

        InputSystem.onDeviceChange += InputSystem_onDeviceChange;

        if (indexPlayer == 0)
        {
            controls.Player1.MovementHorizontal.performed += ctx => moveHorizontal = ctx.ReadValue<float>();
            controls.Player1.MovementHorizontal.canceled += ctx => moveHorizontal = 0f;

            controls.Player1.MovementVertical.performed += ctx => moveVertical = ctx.ReadValue<float>();
            controls.Player1.MovementVertical.canceled += ctx => moveVertical = 0f;

            controls.Player1.Jump.performed += ctx => Jump();

            controls.Player1.Crouch.performed += ctx => Crouch();
            controls.Player1.Crouch.canceled += ctx => UnCrouch();
        }
        else if (indexPlayer == 1)
        {
            controls.Player2.MovementHorizontal.performed += ctx => moveHorizontal = ctx.ReadValue<float>();
            controls.Player2.MovementHorizontal.canceled += ctx => moveHorizontal = 0f;

            controls.Player2.MovementVertical.performed += ctx => moveVertical = ctx.ReadValue<float>();
            controls.Player2.MovementVertical.canceled += ctx => moveVertical = 0f;

            controls.Player2.Jump.performed += ctx => Jump();

            controls.Player2.Crouch.performed += ctx => Crouch();
            controls.Player2.Crouch.canceled += ctx => UnCrouch();
        }

        // Override devices array to have good device connected to the player
        controls.devices = GetAvailableDevices();
    }

    #region MANAGE GAMEPADS
    // Provide Keyboard and Gamepad if available
    private InputDevice[] GetAvailableDevices()
    {
        Gamepad pad = GetGamePadAvailable();
        InputDevice[] devicesAvailable = null;
        if (pad == null)
        {
            devicesAvailable = new InputDevice[1];
            devicesAvailable[0] = Keyboard.current;
        }
        else
        {
            devicesAvailable = new InputDevice[2];
            devicesAvailable[0] = Keyboard.current;
            devicesAvailable[1] = pad;
        }
        return devicesAvailable;
    }

    // Provide an available GamePad if available according to index player
    private Gamepad GetGamePadAvailable()
    {
        // Parse and retrieve Game Pad if available
        int indexPad = 0;
        // According to the index player
        foreach (Gamepad gamePad in Gamepad.all)
        {
            if (indexPad == indexPlayer)
            {
                return gamePad;
            }
            indexPad++;
        }
        return null;
    }

    // Detect if a device is plugged/unplugged and reset playercontrols.devicess
    private void InputSystem_onDeviceChange(InputDevice arg1, InputDeviceChange arg2)
    {
        controls.devices = GetAvailableDevices();
    }
    #endregion MANAGE GAMEPADS

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 desiredMove = (transform.forward * moveVertical) + (transform.right * moveHorizontal);
        desiredMove = Vector3.ClampMagnitude(desiredMove, 1f);

        Vector3 targetPos = transform.position + desiredMove * speed;

        rb.MovePosition(targetPos);

        velocity.y += gravity;

        rb.velocity = velocity;
    }

    private void Jump()
    {
        if (isGrounded)
        {
            print("Press jump");
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
            rb.velocity = velocity;
        }
    }

    private void Crouch()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
    }

    private void UnCrouch()
    {
        transform.localScale = InitScale;
    }


    private void OnEnable()
    {
        controls.Player1.Enable();
        controls.Player2.Enable();
    }

    private void OnDisable()
    {
        controls.Player1.Disable();
        controls.Player2.Disable();
    }
}