using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraV1 : MonoBehaviour
{
    //public GameObject player;
    //public float rotateAngle = 90f;

    public PlayerInputMovement PlayerStat;

    public Transform target;

    public Vector3 offset;

    public bool useOffsetValues;

    public float rotateSpeed;

    public Transform pivot;


    public float verticalLimitLow = 1.5f;
    public float verticalLimitHigh = 10f;

    private float horizontal;
    private float vertical;

    private float desiredXAngle;
    private float desiredYAngle;

    private Quaternion rotation;

    private void Start()
    {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        //Cursor.lockState = CursorLockMode.Locked;     //Cacher la souris sur l'écran
    }
    void LateUpdate()
    {
        /*
        if (PlayerStat.nbreGamepadConnected == 2)
        {
            ControlCamera2Gamepads();
        }
        else if (PlayerStat.nbreGamepadConnected == 1)
        {
            ControlCameraGamepadKeyboard();
        }
        else if (PlayerStat.nbreGamepadConnected == 0)
        {
            ControlCameraKeyboard();
        }*/
    }

    private void ControlCameraKeyboard()
    {
        if (PlayerStat.indexPlayer == 0)
        {
            horizontal = Input.GetAxis("Mouse X Player 1") * rotateSpeed * 5f;
            target.Rotate(0f, horizontal, 0f);

            vertical = Input.GetAxis("Mouse Y Player 1") * rotateSpeed * 5f;
            pivot.Rotate(-vertical, 0f, 0f);
        }

        if (PlayerStat.indexPlayer == 1)
        {
            horizontal = Input.GetAxis("Mouse X Player 2") * rotateSpeed;
            target.Rotate(0f, horizontal, 0f);

            vertical = Input.GetAxis("Mouse Y Player 2") * rotateSpeed;
            pivot.Rotate(-vertical, 0f, 0f);
        }

        desiredYAngle = target.eulerAngles.y;
        desiredXAngle = pivot.eulerAngles.x;

        rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

        transform.position = target.position - (rotation * offset);


        //transform.position = target.position - offset;

        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - 5f, transform.position.z);
        }

        transform.LookAt(target);
    }

    private void ControlCameraGamepadKeyboard()
    {
        if (PlayerStat.indexPlayer == 0)
        {
            horizontal = hinput.gamepad[PlayerStat.indexPlayer].rightStick.horizontal * rotateSpeed;
            target.Rotate(0f, horizontal, 0f);

            vertical = hinput.gamepad[PlayerStat.indexPlayer].rightStick.vertical * rotateSpeed;
            pivot.Rotate(-vertical, 0f, 0f);
        }
        else if (PlayerStat.indexPlayer == 1)
        {
            horizontal = Input.GetAxis("Mouse X Player 2") * rotateSpeed;
            target.Rotate(0f, horizontal, 0f);

            vertical = Input.GetAxis("Mouse Y Player 2") * rotateSpeed;
            pivot.Rotate(-vertical, 0f, 0f);
        }

        desiredYAngle = target.eulerAngles.y;
        desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

        transform.position = target.position - (rotation * offset);


        //transform.position = target.position - offset;

        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - 5f, transform.position.z);
        }

        transform.LookAt(target);
    }

    private void ControlCamera2Gamepads()
    {
        horizontal = hinput.gamepad[PlayerStat.indexPlayer].rightStick.horizontal * rotateSpeed;
        target.Rotate(0f, horizontal, 0f);

        vertical = hinput.gamepad[PlayerStat.indexPlayer].rightStick.vertical * rotateSpeed;
        pivot.Rotate(-vertical, 0f, 0f);

        desiredYAngle = target.eulerAngles.y;
        desiredXAngle = pivot.eulerAngles.x;

        rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

        transform.position = target.position - (rotation * offset);


        //transform.position = target.position - offset;

        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - 5f, transform.position.z);
        }

        transform.LookAt(target);
    }


}
