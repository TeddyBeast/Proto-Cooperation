using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CourteEchelle : MonoBehaviour
{
    PlayerControls controls;

    public Animator Anim;

    [Header("Settings")]
    [SerializeField] private PlayerInputMovement PlayerSettings;

    [SerializeField] private AffichageUI UIPropulsion;

    public enum player { Player1, Player2 }
    public player Player;

    public float powerProjection = 100f;

    [Header("Debug")]
    [SerializeField] List<GameObject> playerTouched = new List<GameObject>();
    [SerializeField] private bool projectedPressed = false;
    [SerializeField] private bool otherPlayerTouched = false;

    private void Start()
    {
        UIPropulsion.DisableImage();

        projectedPressed = false;
        otherPlayerTouched = false;
    }

    private void Awake()
    {
        controls = new PlayerControls();

        InputSystem.onDeviceChange += InputSystem_onDeviceChange;

        if (Player == player.Player1)
        {
            controls.Player1.CourteEchelle.started += ctx => projectedPressed = true;
            controls.Player1.CourteEchelle.canceled += ctx => projectedPressed = false;
        }
        else if (Player == player.Player2)
        {
            controls.Player2.CourteEchelle.performed += ctx => projectedPressed = true;
            controls.Player2.CourteEchelle.canceled += ctx => projectedPressed = false;
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
        if (Player == player.Player1)
        {
            if (otherPlayerTouched == true && projectedPressed == true)
            {
                Anim.Play("Projete");
                GameObject GO = playerTouched[0];
                GO.GetComponent<PlayerInputMovement>().SuperJump(powerProjection);
            }
        }
        if (Player == player.Player2)
        {
            if (otherPlayerTouched == true && projectedPressed == true)
            {
                Anim.Play("Projete");
                GameObject GO = playerTouched[0];
                GO.GetComponent<PlayerInputMovement>().SuperJump(powerProjection);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Player == player.Player1)
        {
            if (other.gameObject.CompareTag("Player 2"))
            {
                playerTouched.Add(other.gameObject);
                UIPropulsion.EnableImage();
                otherPlayerTouched = true;
            }
        }
        if (Player == player.Player2)
        {
            if (other.gameObject.CompareTag("Player 1"))
            {
                playerTouched.Add(other.gameObject);
                UIPropulsion.EnableImage();
                otherPlayerTouched = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Player == player.Player1)
        {
            if (other.gameObject.CompareTag("Player 2"))
            {
                otherPlayerTouched = false;
                UIPropulsion.DisableImage();
                playerTouched.Clear();
            }
        }
        if (Player == player.Player2)
        {
            if (other.gameObject.CompareTag("Player 1"))
            {
                otherPlayerTouched = false;
                UIPropulsion.DisableImage();
                playerTouched.Clear();
            }
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
