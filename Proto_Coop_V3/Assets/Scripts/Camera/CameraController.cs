using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraController : MonoBehaviour
{
    PlayerControls controls;

    [Header("Settings")]
    public bool lockCursor;
    public float sensivity = 2f;
    public Transform target;
    public PlayerInputMovement PlayerStat;
    public float distFromTarget = 11f;
    public Vector2 pitchMinMax = new Vector2(-40f, 85f);

    public float rotationSmoothTime = 10f;
    Vector3 currentRotation;

    float h;
    float v;

    float moveH;
    float moveV;

    [Header("Aiming Vars")]
    public Vector3 playerOffset;
    public float distanceFromOffset = 2f;
    public Transform rotator;

    [Header("Transparency")]
    public bool changeTransparency = true;
    public MeshRenderer targetRenderer;

    [Header("Speeds")]
    public float moveSpeed = 5f;
    public float returnSpeed = 9f;
    public float wallPush = 0.16f;

    [Header("Distances")]
    public float closestDistanceToPlayer = 2f;
    public float evenCloserDistanceToPlayer = 1f;

    [Header("Mask")]
    public LayerMask collisionMask;

    private bool vLock = false;

    InputDevice[] devicesAvailable = null;

    public bool aimPressed = false;
    public bool aimHold = false;
    public bool aimRelease = true;

    private void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        aimRelease = true;
    }

    private void Awake()
    {
        controls = new PlayerControls();

        InputSystem.onDeviceChange += InputSystem_onDeviceChange;

        if (PlayerStat.indexPlayer == 0)
        {
            controls.Player1.CameraHorizontal.performed += ctx => moveH = ctx.ReadValue<float>();
            controls.Player1.CameraHorizontal.canceled += ctx => moveH = 0f;

            controls.Player1.CameraVertical.performed += ctx => moveV = ctx.ReadValue<float>();
            controls.Player1.CameraVertical.canceled += ctx => moveV = 0f;

            controls.Player1.Aim.started += ctx => aimPressed = true;
            controls.Player1.Aim.performed += ctx => aimHold = true;
            controls.Player1.Aim.canceled += ctx => aimRelease = true;
        }

        else if (PlayerStat.indexPlayer == 1)
        {
            controls.Player2.CameraHorizontal.performed += ctx => moveH = ctx.ReadValue<float>();
            controls.Player2.CameraHorizontal.canceled += ctx => moveH = 0f;

            controls.Player2.CameraVertical.performed += ctx => moveV = ctx.ReadValue<float>();
            controls.Player2.CameraVertical.canceled += ctx => moveV = 0f;
            
            controls.Player2.Aim.started += ctx => aimPressed = true;
            controls.Player2.Aim.performed += ctx => aimHold = true;
            controls.Player2.Aim.canceled += ctx => aimRelease = true;
        }

        // Override devices array to have good device connected to the player
        controls.devices = GetAvailableDevices();
    }

    # region MANAGE GAMEPADS
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

    private void OnDrawGizmos()
    {
        Vector3 r = target.TransformPoint(playerOffset);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(r, 0.1f);
    }

    private void ThirdPersonAiming()
    {
        CollisionCheck((target.TransformPoint(playerOffset) - transform.forward * distanceFromOffset));


        h += moveH * sensivity;
        v -= moveV * sensivity;
        v = Mathf.Clamp(v, pitchMinMax.x, pitchMinMax.y);
        currentRotation = Vector3.Lerp(currentRotation, new Vector3(v, h), rotationSmoothTime * Time.deltaTime);

        transform.eulerAngles = currentRotation;
        Vector3 e = transform.eulerAngles;
        e.x = 0;
        Vector3 g = transform.eulerAngles;
        g.y = 0;

        rotator.eulerAngles = new Vector3(g.x, rotator.eulerAngles.y, rotator.eulerAngles.z);

        target.eulerAngles = e;
    }

    private void LateUpdate()
    {
        if (PlayerStat.indexPlayer == 1 && devicesAvailable.Length < 2)
        {
            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                aimPressed = true;
                aimHold = true;
                aimRelease = false;
            }
            else if (Mouse.current.rightButton.wasReleasedThisFrame)
            {
                aimPressed = false;
                aimHold = false;
                aimRelease = true;
            }

            moveH = Input.GetAxis("Mouse X");
            moveV = Input.GetAxis("Mouse Y");
        }
        

        if (aimPressed == true)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
            aimPressed = false;
            aimRelease = false;
        }
        if (aimHold == true)
        {
            ThirdPersonAiming();
            Transparency(0.2f);
        }
        if (aimRelease == true)
        {
            aimHold = false;
            aimPressed = false;

            rotator.eulerAngles = new Vector3(0, rotator.eulerAngles.y, rotator.eulerAngles.z);

            CollisionCheck(target.position - transform.forward * distFromTarget);
            WallCheck();

            if (!vLock)
            {
                h += moveH * sensivity;
                v -= moveV * sensivity;
                v = Mathf.Clamp(v, pitchMinMax.x, pitchMinMax.y);
                currentRotation = Vector3.Lerp(currentRotation, new Vector3(v, h), rotationSmoothTime * Time.deltaTime);
            }
            else
            {
                h += moveV * sensivity;
                v = pitchMinMax.y;

                currentRotation = Vector3.Lerp(currentRotation, new Vector3(v, h), rotationSmoothTime * Time.deltaTime);
            }

            transform.eulerAngles = currentRotation;

            Vector3 e = transform.eulerAngles;
            e.x = 0;

            target.eulerAngles = e;
        }
    }

    private void WallCheck()
    {
        Ray ray = new Ray(target.position, -target.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.2f, out hit, 0.7f, collisionMask))
        {
            vLock = true;
        }
        else
        {
            vLock = false;
        }
    }

    private void CollisionCheck(Vector3 retPoint)
    {
        RaycastHit hit;

        if (Physics.Linecast(target.position, retPoint, out hit, collisionMask))
        {
            Vector3 norm = hit.normal * wallPush;
            Vector3 p = hit.point + norm;

            TransparencyCheck();

            if (Vector3.Distance(Vector3.Lerp(transform.position, p, moveSpeed * Time.deltaTime), target.position) <= evenCloserDistanceToPlayer)
            {

            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, p, moveSpeed * Time.deltaTime);
            }
            return;
        }

        FullTransparency();

        transform.position = Vector3.Lerp(transform.position, retPoint, returnSpeed * Time.deltaTime);
        vLock = false;
    }

    private void TransparencyCheck()
    {
        if (changeTransparency)
        {
            if (Vector3.Distance(transform.position, target.position) <= closestDistanceToPlayer)
            {
                Color temp = targetRenderer.sharedMaterial.color;
                temp.a = Mathf.Lerp(temp.a, 0.2f, moveSpeed * Time.deltaTime);

                targetRenderer.sharedMaterial.color = temp;
            }
            else
            {
                if (targetRenderer.sharedMaterial.color.a <= 0.99f)
                {

                    Color temp = targetRenderer.sharedMaterial.color;
                    temp.a = Mathf.Lerp(temp.a, 1, moveSpeed * Time.deltaTime);

                    targetRenderer.sharedMaterial.color = temp;
                }
            }
        }
    }

    private void FullTransparency()
    {
        if (changeTransparency)
        {
            if (targetRenderer.sharedMaterial.color.a <= 0.99f)
            {
                Color temp = targetRenderer.sharedMaterial.color;
                temp.a = Mathf.Lerp(temp.a, 1, moveSpeed * Time.deltaTime);

                targetRenderer.sharedMaterial.color = temp;
            }
        }
    }

    private void Transparency(float t)
    {
        Color temp = targetRenderer.sharedMaterial.color;
        temp.a = Mathf.Lerp(temp.a, t, moveSpeed * Time.deltaTime);

        targetRenderer.sharedMaterial.color = temp;
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
