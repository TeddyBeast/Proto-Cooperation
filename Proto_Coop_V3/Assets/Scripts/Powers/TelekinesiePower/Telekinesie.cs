using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Telekinesie : MonoBehaviour
{
    PlayerControls controls;

    [Header("Settings")]
    [SerializeField] private PlayerInputMovement PlayerSettings;

    [SerializeField] CameraController CamValues;
    [SerializeField] Transform CamTransform;

    [SerializeField] private Image Crosshair;

    public ListMovablePlatforms ListPlateforms;

    private GameObject PlateformTouched;

    public float speedPlatform = 7f;

    float moveH;
    float moveV;

    [Header("Debug")]
    [SerializeField] private bool powerActivate = false;


    private void Start()
    {
        ListPlateforms = FindObjectOfType(typeof(ListMovablePlatforms)) as ListMovablePlatforms;
        PlayerSettings = GetComponent<PlayerInputMovement>();
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

        if (CamValues.aimHold == true)
        {
            Crosshair.enabled = enabled;

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                Debug.DrawRay(CamTransform.transform.position, CamTransform.transform.forward * 1000f, Color.red);

                foreach (GameObject plateform in ListPlateforms.PlateformMovableTelekinesie)
                {
                    if (hit.transform.gameObject == plateform)
                    {
                        PlateformTouched = plateform;
                        PlateformTouched.GetComponent<Outline>().enabled = true;

                        powerActivate = true;
                    }
                }
            }
        }

        if (CamValues.aimRelease == true)
        {
            PlayerSettings.enabled = enabled;
            Crosshair.enabled = false;

            foreach (GameObject plateform in ListPlateforms.PlateformMovableTelekinesie)
            {
                plateform.GetComponent<Outline>().enabled = false;
            }

            powerActivate = false;
        }


        if (powerActivate == true)
        {
            PlayerSettings.enabled = false;

            Rigidbody rb;
            rb = PlateformTouched.transform.GetComponent<Rigidbody>();

            float h = moveH;
            float v = moveV;

            Vector3 desiredMove = (transform.forward * v) + (transform.right * h);
            desiredMove = Vector3.ClampMagnitude(desiredMove, 1f);

            Vector3 targetPos = PlateformTouched.transform.position + desiredMove * speedPlatform * Time.deltaTime;

            rb.MovePosition(targetPos);
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
