using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PositionSave : MonoBehaviour
{
    PlayerControls controls;

    [Header("Settings")]
    [SerializeField] private PlayerInputMovement PlayerSettings;

    public bool playerDead = false;
    public GameObject OtherPlayer;

    public Vector3 SavePos;

    public Animator Anim;

    public bool SavePressed = false;

    private void Start()
    {
        SavePressed = false;
        PlayerSettings = GetComponent<PlayerInputMovement>();

        Anim = GetComponentInChildren<Animator>();
    }


    private void Awake()
    {
        controls = new PlayerControls();

        InputSystem.onDeviceChange += InputSystem_onDeviceChange;

        if (PlayerSettings.indexPlayer == 0)
        {
            controls.Player1.ValidateCheckpoint.performed += ctx => SavePressed = true;
            controls.Player1.ValidateCheckpoint.canceled += ctx => SavePressed = false;
        }

        else if (PlayerSettings.indexPlayer == 1)
        {
            controls.Player2.ValidateCheckpoint.performed += ctx => SavePressed = true;
            controls.Player2.ValidateCheckpoint.canceled += ctx => SavePressed = false;
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
            if (indexPad == PlayerSettings.indexPlayer)
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

    private void Update()
    {
        if (SavePressed == true)
        {
            Anim.Play("Checkpray");
        }
        
    }

    void Respawn()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Mort");
        transform.position = SavePos;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerDead = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Agent Hostile")
        {
            OtherPlayer.GetComponent<PositionSave>().Respawn();
            Respawn();
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