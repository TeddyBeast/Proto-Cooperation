using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPlayerMovement : MonoBehaviour
{
    public int nbreGamepadConnected;

    public float speed = 7f;
    public int Player = 3;

    private float h;
    private float v;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        nbreGamepadConnected = Input.GetJoystickNames().Length;

    }

    private void FixedUpdate()
    {
        print("Nombre de manettes connect : " + nbreGamepadConnected);

        if (nbreGamepadConnected == 2)
        {
            Controls2Gamepads();
        }

        if (nbreGamepadConnected == 1)
        {
            ControlsGamepadKeyboard();
        }

        if (nbreGamepadConnected == 0)
        {
            ControlsKeyboards();
        }

    }

    private void ControlsKeyboards()
    {
        h = Input.GetAxis("HorizontalPlayer1");
        v = Input.GetAxis("VerticalPlayer1");

        Vector3 desiredMove = (transform.forward * v) + (transform.right * h);
        desiredMove = Vector3.ClampMagnitude(desiredMove, 1f);

        Vector3 targetPos = transform.position + desiredMove * speed * Time.deltaTime;

        rb.MovePosition(targetPos);
    }

    private void ControlsGamepadKeyboard()
    {
        h = hinput.gamepad[0].leftStick.horizontal;
        v = hinput.gamepad[0].leftStick.vertical;

        Vector3 desiredMove = (transform.forward * v) + (transform.right * h);
        desiredMove = Vector3.ClampMagnitude(desiredMove, 1f);

        Vector3 targetPos = transform.position + desiredMove * speed * Time.deltaTime;

        rb.MovePosition(targetPos);
    }

    private void Controls2Gamepads()
    {
        h = hinput.gamepad[0].leftStick.horizontal;
        v = hinput.gamepad[0].leftStick.vertical;

        Vector3 desiredMove = (transform.forward * v) + (transform.right * h);
        desiredMove = Vector3.ClampMagnitude(desiredMove, 1f);

        Vector3 targetPos = transform.position + desiredMove * speed * Time.deltaTime;

        rb.MovePosition(targetPos);
    }
}
