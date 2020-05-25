using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PortalPower : MonoBehaviour
{
    PlayerControls controls;

    Vector3 portalRotate = new Vector3(90,0,0);

    public Animator Anim;

    [Header("Settings")]
    [SerializeField] private PlayerInputMovement PlayerSettings;

    [SerializeField] private GameObject PortalA;
    [SerializeField] private GameObject PortalB;
    [SerializeField] private GameObject PortalSelected;

    [SerializeField] private float distWall = 2f;

    public ListPortalsPlaced ListPortals;

    private int NbreSamePortal = 0;

    [Header("Debug")]
    [SerializeField] private bool inputPlacePortalPressed = false;
    [SerializeField] private bool inputSwitchPortalPressed = false;

    private void Start()
    {
        ListPortals = FindObjectOfType(typeof(ListPortalsPlaced)) as ListPortalsPlaced;
        PortalSelected = PortalA;
    }

    private void Awake()
    {
        controls = new PlayerControls();

        InputSystem.onDeviceChange += InputSystem_onDeviceChange;

        if (PlayerSettings.indexPlayer == 0)
        {
            controls.Player1.AddPortal.started += ctx => inputPlacePortalPressed = true;

            controls.Player1.SwitchPortal.started += ctx => inputSwitchPortalPressed = true;
        }

        else if (PlayerSettings.indexPlayer == 1)
        {
            controls.Player2.AddPortal.started += ctx => inputPlacePortalPressed = true;

            controls.Player2.SwitchPortal.started += ctx => inputSwitchPortalPressed = true;
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
        Ray ray = new Ray(PlayerSettings.Pivot.transform.position, transform.forward);

        if (inputPlacePortalPressed == true)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, distWall))
            {
                Debug.DrawRay(PlayerSettings.Pivot.transform.position, transform.forward * distWall, Color.red);

                if (hit.transform.CompareTag("Wall"))
                {
                    if (ListPortals.PortalsPlaced.Count == 0)
                    {
                        ListPortals.PortalsPlaced.Add(Instantiate(PortalSelected, transform.position + transform.forward, Quaternion.Euler(90, 0, 0)/*transform.rotation = hit.transform.rotation*/));
                        Anim.Play("Portail");
                        FMODUnity.RuntimeManager.PlayOneShot("event:/Placer Portail", transform.position);
                    }
                    
                    if (ListPortals.PortalsPlaced.Count > 0)
                    {
                        if (NbreSamePortal == 0)
                        {
                            ListPortals.PortalsPlaced.Add(Instantiate(PortalSelected, transform.position + transform.forward, Quaternion.Euler(90,0,0)/*transform.rotation = hit.transform.rotation*/));
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Placer Portail", transform.position);
                            Anim.Play("Portail");
                            NbreSamePortal = 0;
                        }
                        
                        foreach (GameObject portal in ListPortals.PortalsPlaced)
                        {
                            if (portal.tag == PortalSelected.tag)
                            {
                                portal.transform.position = transform.position + transform.up * 3 + transform.forward * 0.5f;
                                //portal.transform.rotation = hit.transform.rotation;
                                FMODUnity.RuntimeManager.PlayOneShot("event:/Placer Portail", transform.position);
                                NbreSamePortal++;
                            }
                        }
                        NbreSamePortal = 0;
                    }
                    
                }
            }

            inputPlacePortalPressed = false;
        }


        //Switch Portal
        if (inputSwitchPortalPressed == true)
        {
            if (PortalSelected == PortalA)
            {
                PortalSelected = PortalB;
            }
            else if (PortalSelected == PortalB)
            {
                PortalSelected = PortalA;
            }

            inputSwitchPortalPressed = false;
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
