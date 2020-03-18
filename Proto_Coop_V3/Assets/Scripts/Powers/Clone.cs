using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Clone : MonoBehaviour
{
    PlayerControls controls;
    public PlayerInputMovement PlayerStat;

    public Rigidbody rb;
    //public GameObject cloneGO;
    //public Vector3 playerVelocity;
    //private GameObject clone;
    public bool cloned = false;
    public Material Shadow;
    public Material OldMaterial;

    bool clonePressed = false;

    private void Awake()
    {
        controls = new PlayerControls();

        InputSystem.onDeviceChange += InputSystem_onDeviceChange;

        if (PlayerStat.indexPlayer == 0)
        {
            controls.Player1.Clone.started += ctx => clonePressed = true;
            controls.Player1.Clone.canceled += ctx => clonePressed = false;
        }
        else if (PlayerStat.indexPlayer == 1)
        {
            controls.Player2.Clone.started += ctx => clonePressed = true;
            controls.Player2.Clone.canceled += ctx => clonePressed = false;
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
        clonePressed = false;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P) & cloned)
        //{
        //    Destroy(clone);
        //}
        if (clonePressed == true & !cloned)
        {
            //clone = Instantiate(cloneGO, transform.position, transform.rotation);

            //OldMaterial = GetComponent<MeshRenderer>().material;
            GetComponent<MeshRenderer>().material = Shadow;

            //playerVelocity = rb.velocity;
            //clone.GetComponent<Rigidbody>().AddForce(playerVelocity * 2 + Vector3.up * 5, ForceMode.VelocityChange);
            //clone.GetComponent<BoxCollider>().enabled = false;
            //StartCoroutine(RebuildCollision());
            cloned = true;
            gameObject.layer = 12;
        }
        if (clonePressed == false & cloned)
        {
            //transform.position = clone.transform.position;
            //Destroy(clone);
            GetComponent<MeshRenderer>().material = OldMaterial;
            cloned = false;
            gameObject.layer = 0;
        }
    }

    //public void OnCollisionEnter(Collision col)
    //{
    //    if (cloned & col.gameObject.layer == 11)
    //    {

    //    }
    //}


    //IEnumerator RebuildCollision()
    //{
    //    if (cloned)
    //    {
    //        yield return new WaitForSeconds(0.01f);
    //        clone.GetComponent<BoxCollider>().enabled = true;
    //    }
    //}

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
