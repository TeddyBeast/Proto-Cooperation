using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectiles : MonoBehaviour
{
    PlayerControls controls;
    InputDevice[] devicesAvailable = null;

    public Animator Anim;

    [Header("Settings")]
    public GameObject Projectile;
    public Transform SpawnPoint;
    [SerializeField] private PlayerInputMovement PlayerSettings;
    [SerializeField] private CameraController CameraSettings;
    [SerializeField] private GameObject CameraTransform;
    public float powerShoot = 3f;

    [Header("Debug")]
    [SerializeField] private bool shootPressed = false;

    private void Start()
    {
        shootPressed = false;
    }

    private void Awake()
    {
        controls = new PlayerControls();

        InputSystem.onDeviceChange += InputSystem_onDeviceChange;

        if (PlayerSettings.indexPlayer == 0)
        {
            controls.Player1.Shoot.started += ctx => shootPressed = true;
            controls.Player1.Shoot.canceled += ctx => shootPressed = false;
        }
        else if (PlayerSettings.indexPlayer == 1)
        {
            controls.Player2.Shoot.performed += ctx => shootPressed = true;
            controls.Player2.Shoot.canceled += ctx => shootPressed = false;
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

    private void FixedUpdate()
    {
        if (PlayerSettings.indexPlayer == 1 && devicesAvailable.Length < 2)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                shootPressed = true;
            }
            else if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                shootPressed = false;
            }
        }

        if (shootPressed == true && CameraSettings.aimHold == true)
        {
            GameObject GO = Instantiate(Projectile, SpawnPoint.transform.position, CameraTransform.transform.rotation);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Tir", transform.position);
            GO.GetComponent<Rigidbody>().AddForce(CameraTransform.transform.forward * powerShoot, ForceMode.Impulse);
            shootPressed = false;
            Anim.Play("Coconut");
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
