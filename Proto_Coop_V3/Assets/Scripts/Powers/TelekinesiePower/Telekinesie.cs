using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Telekinesie : MonoBehaviour
{
    PlayerControls controls;

    public Animator Anim;

    [Header("Settings")]
    [SerializeField] private PlayerInputMovement PlayerSettings;

    [SerializeField] CameraController CamValues;
    [SerializeField] Transform CamTransform;

    [SerializeField] Image TelekinesieUI;

    public float speedPlatform = 7f;

    float moveH;
    float moveV;

    private FMOD.Studio.EventInstance event_fmod;

    GameObject plateform;

    Rigidbody rb;

    [Header("Debug")]
    [SerializeField] private bool powerActivate = false;

    private void Start()
    {
        PlayerSettings = GetComponent<PlayerInputMovement>();
        event_fmod = FMODUnity.RuntimeManager.CreateInstance("event:/Télékinésie");
    }


    private void Awake()
    {
        controls = new PlayerControls();

        InputSystem.onDeviceChange += InputSystem_onDeviceChange;

        if (PlayerSettings.indexPlayer == 0)
        {
            controls.Player1.MovementHorizontal.performed += ctx => moveH = ctx.ReadValue<float>();
            controls.Player1.MovementHorizontal.canceled += ctx => moveH = 0f;

            controls.Player1.MovementVertical.performed += ctx => moveV = ctx.ReadValue<float>();
            controls.Player1.MovementVertical.canceled += ctx => moveV = 0f;
        }

        else if (PlayerSettings.indexPlayer == 1)
        {
            controls.Player2.MovementHorizontal.performed += ctx => moveH = ctx.ReadValue<float>();
            controls.Player2.MovementHorizontal.canceled += ctx => moveH = 0f;

            controls.Player2.MovementVertical.performed += ctx => moveV = ctx.ReadValue<float>();
            controls.Player2.MovementVertical.canceled += ctx => moveV = 0f;
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
        Ray ray = new Ray(CamTransform.transform.position, CamTransform.transform.forward);
        event_fmod.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));

        if (CamValues.aimHold == true && powerActivate == false)
        {
            TelekinesieUI.color = new Color(TelekinesieUI.color.r, TelekinesieUI.color.g, TelekinesieUI.color.b, 0.65f);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
            {
                Debug.DrawRay(CamTransform.transform.position, CamTransform.transform.forward * 1000f, Color.red);

                if (hit.transform.CompareTag("Movable Plateform"))
                {
                    plateform = hit.transform.gameObject;
                    event_fmod.start();
                    FMODUnity.RuntimeManager.PlayOneShot("event:/StartTélékinésie");
                    powerActivate = true;
                }
            }
        }

        if (powerActivate == true)
        {
            // Rotate perso en fonction de la cam
            transform.rotation = PlayerSettings.Pivot.transform.rotation;

            Anim.SetBool("BreakTelekynesie", false);
            Anim.Play("TelekynesieLoop");
            PlayerSettings.enabled = false;

            rb = plateform.transform.GetComponent<Rigidbody>();
            rb.isKinematic = false;

            float h = moveH;
            float v = moveV;

            Vector3 desiredMove = (transform.forward * v) + (transform.right * h);
            desiredMove = Vector3.ClampMagnitude(desiredMove, 1f);

            Vector3 targetPos = plateform.transform.position + desiredMove * speedPlatform * Time.deltaTime;

            rb.MovePosition(targetPos);
        }


        if (CamValues.aimRelease == true)
        {
            TelekinesieUI.color = new Color(TelekinesieUI.color.r, TelekinesieUI.color.g, TelekinesieUI.color.b, 1f);
            powerActivate = false;
            PlayerSettings.enabled = enabled;
            //Crosshair.enabled = false;
            Anim.SetBool("BreakTelekynesie", true);
            event_fmod.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

            if (plateform != null)
            {
                rb.isKinematic = true;
            }
        }
    }

    #region ACTIVATE CONTROLS
    private void OnEnable()
    {
        controls.Player1.Enable();
        controls.Player2.Enable();

        TelekinesieUI.enabled = true;
    }

    private void OnDisable()
    {
        controls.Player1.Disable();
        controls.Player2.Disable();
        TelekinesieUI.enabled = false;
    }
    #endregion ACTIVATE CONTROLS
}
