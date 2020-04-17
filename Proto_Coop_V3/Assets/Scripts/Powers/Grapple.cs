using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Grapple : MonoBehaviour
{
    PlayerControls controls;

    [Header("Settings")]
    public GameObject hookStart;

    public GameObject hookEnd;
    //public Camera cameraMire;
    public bool targeted = false;
    private GameObject HookEndGO;
    private Rigidbody rb;
    public LineRenderer LR;
    public SpringJoint Rope;

    [SerializeField] CameraController CamValues;
    [SerializeField] Transform CamTransform;

    [SerializeField] private PlayerInputMovement PlayerStat;

    [SerializeField] private Image Crosshair;
    //public GameObject CameraVise;

    bool ThrowGrapple = false;

    float ropeLength = 1;
    bool attached = false;

    private void Awake()
    {
        controls = new PlayerControls();

        InputSystem.onDeviceChange += InputSystem_onDeviceChange;

        if (PlayerStat.indexPlayer == 0)
        {
            controls.Player1.ThrowBreakGrapple.performed += ctx => ThrowGrapple = true;
            controls.Player1.ThrowBreakGrapple.canceled += ctx => ThrowGrapple = false;
        }
        else if (PlayerStat.indexPlayer == 1)
        {
            controls.Player2.ThrowBreakGrapple.performed += ctx => ThrowGrapple = true;
            controls.Player2.ThrowBreakGrapple.canceled += ctx => ThrowGrapple = false;
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
            if (indexPad == PlayerStat.indexPlayer)
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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ThrowGrapple = false;
        LR = GetComponent<LineRenderer>();
        ropeLength = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ThrowGrapple == true & targeted)
        {
            //Debug.Log("Shooting");
            ShootHook();
            attached = true;
        }
        if (CamValues.aimHold == true & !targeted)
        {
            //CameraVise.SetActive(true);
            //transform.GetChild(0).gameObject.SetActive(false);

            Vector3 forward = CamTransform.transform.TransformDirection(Vector3.forward) * 1000;

            Debug.DrawRay(CamTransform.transform.position, forward, Color.green);

            RaycastHit hit;
            if (Physics.Raycast(CamTransform.transform.position, forward, out hit) && (hit.transform.tag == "Grap"))
            {
                if (!targeted)
                {
                    //Debug.Log("target");
                    HookEndGO = Instantiate(hookEnd, hit.point, Quaternion.identity);
                    targeted = true;
                }
                else
                {
                    HookEndGO.transform.position = hit.point;
                }

            }
            else
            {
                //targeted = false;
                //Destroy(HookEndGO);
            }
        }

        //if (!targeted)
        //{
        //    targeted = false;
        //    Destroy(HookEndGO);
        //    //LR.enabled = false;
        //    LR.positionCount = 0;
        //    Rope = null;
        //    Destroy(GetComponent<SpringJoint>());
        //}

        if (attached && CamValues.aimHold == true)
        {
            ReleaseRope();
            attached = false;
            LR.enabled = false;
            targeted = false;
        }

        Ray ray = new Ray(CamTransform.transform.position, CamTransform.transform.forward);

        if (CamValues.aimHold == true)
        {
            Crosshair.enabled = enabled;

            if (Physics.Raycast(ray, out RaycastHit hit, 1000))
            {
                //Debug.DrawRay(CamTransform.transform.position, CamTransform.transform.forward * 1000f, Color.red);

               
            }
        }

        if (CamValues.aimRelease == true)
        {
            PlayerStat.enabled = enabled;
            Crosshair.enabled = false;
        }
    }

    private void LateUpdate()
    {
        if (targeted)
        {
            DrawRope();
        }
    }

    public void ShootHook()
    {
        //Destroy(Rope);
        //LR.enabled = true;
        //LR.positionCount = 2;

        if (GetComponent<SpringJoint>() == null)
        {
            Rope = gameObject.AddComponent<SpringJoint>();
            Rope.anchor = Vector3.zero;
        }
        float distanceRope = Vector3.Distance(hookStart.transform.position, HookEndGO.transform.position);
        ropeLength -= 0.01f;
        Rope.maxDistance = distanceRope * ropeLength;
        Rope.minDistance = distanceRope * 0.01f;
        //newRope.enableCollision = false;
        Rope.autoConfigureConnectedAnchor = false;
        Rope.connectedAnchor = HookEndGO.transform.position;
        Rope.spring = 10f;
        Rope.damper = 2f;
        Rope.massScale = 10f;
        //GameObject.DestroyImmediate(Rope);
        //Rope = newRope;
    }

    public void ReleaseRope()
    {
        if (GetComponent<SpringJoint>() != null)
        {
            Destroy(GetComponent<SpringJoint>());
        }
        Rope = null;
        Destroy(HookEndGO);
        ropeLength = 1;
    }

    public void DrawRope()
    {
        LR.enabled = true;
        LR.SetPosition(0, hookStart.transform.position);
        LR.SetPosition(1, HookEndGO.transform.position);
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
