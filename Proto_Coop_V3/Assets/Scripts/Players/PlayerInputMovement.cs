using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputMovement : MonoBehaviour
{
    PlayerControls controls;

    public Animator Anim;

    [Header("Settings")]
    public Transform groundCheck;

    public GameObject Pivot;

    public LayerMask groundMask;

    public Rigidbody rb;

    Vector3 InitScale;
    Vector3 velocity;

    public int indexPlayer = 0;

    public float speed = 7f;
    public float groundDistance = 1f;
    public float JumpHeight = 7f;
    public float gravity = -9.81f;

    [Header("Debug")]
    [SerializeField] private bool isGrounded;
    float moveHorizontal;
    float moveVertical;

    private FMOD.Studio.EventInstance event_fmod;

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<Transform>();
        velocity = rb.velocity;

        InitScale = transform.localScale;

        event_fmod = FMODUnity.RuntimeManager.CreateInstance("event:/Marche");
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        controls = new PlayerControls();

        InputSystem.onDeviceChange += InputSystem_onDeviceChange;

        if (indexPlayer == 0)
        {
            controls.Player1.MovementHorizontal.performed += ctx => moveHorizontal = ctx.ReadValue<float>();
            controls.Player1.MovementHorizontal.canceled += ctx => moveHorizontal = 0f;

            controls.Player1.MovementVertical.performed += ctx => moveVertical = ctx.ReadValue<float>();
            controls.Player1.MovementVertical.canceled += ctx => moveVertical = 0f;

            controls.Player1.Jump.performed += ctx => Jump();
        }
        else if (indexPlayer == 1)
        {
            controls.Player2.MovementHorizontal.performed += ctx => moveHorizontal = ctx.ReadValue<float>();
            controls.Player2.MovementHorizontal.canceled += ctx => moveHorizontal = 0f;

            controls.Player2.MovementVertical.performed += ctx => moveVertical = ctx.ReadValue<float>();
            controls.Player2.MovementVertical.canceled += ctx => moveVertical = 0f;

            controls.Player2.Jump.performed += ctx => Jump();
        }

        // Override devices array to have good device connected to the player
        controls.devices = GetAvailableDevices();

        Anim = GetComponentInChildren<Animator>();
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
        // rotate perso en fonction du pivot cam
        transform.rotation = Pivot.transform.rotation;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 desiredMove = (transform.forward * moveVertical) + (transform.right * moveHorizontal);
        desiredMove = Vector3.ClampMagnitude(desiredMove, 1f);

        Vector3 targetPos = transform.position + desiredMove * speed * Time.deltaTime;

        rb.MovePosition(targetPos);

        velocity.y += gravity * Time.deltaTime;

        rb.velocity = velocity;

        if (desiredMove != Vector3.zero)
        {
            if (isGrounded)
            {
                Anim.Play("Walk");
            }
        }

        // Walking Sound
        event_fmod.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));

        if (isGrounded && desiredMove.x == 0f || desiredMove.z == 0f)
        {
            event_fmod.start();
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            print("Press jump");
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
            rb.velocity = velocity;
            event_fmod.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            Anim.Play("Jump");
        }
    }

    public void SuperJump(float powerProjection)
    {
        if (isGrounded)
        {
            print("Press Super jump");
            FMODUnity.RuntimeManager.PlayOneShot("event:/Projection", transform.position);
            velocity.y = Mathf.Sqrt(powerProjection * -2f * gravity);
            rb.velocity = velocity;
        }
    }

    #region ACTIVATE CONTROLS
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
    #endregion ACTIVATE CONTROLS
}