using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int nbreGamepadConnected;

    public float speed = 7f;
    public float powerJump = 7f;
    public int Player;
    public bool isJumping = true;
    public bool canJump = true;

    private float h;
    private float v;

    private float distToGround;
    private Rigidbody rb;

    private Vector3 InitScale;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
        nbreGamepadConnected = Input.GetJoystickNames().Length;
        print("Number of gamepad connected : " + nbreGamepadConnected);

        InitScale = transform.localScale;
    }

    private void FixedUpdate()
    {
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

        if (hinput.gamepad[0].B.justPressed && Player == 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2 , transform.localScale.z);
        }
        else if (hinput.gamepad[0].B.justReleased && Player == 0)
        {
            transform.localScale = InitScale;
        }
    }

    private void ControlsKeyboards()
    {
        if (Player == 0)
        {
            h = Input.GetAxis("HorizontalPlayer1");
            v = Input.GetAxis("VerticalPlayer1");
        }
        else if (Player == 1)
        {
            h = Input.GetAxis("HorizontalPlayer2");
            v = Input.GetAxis("VerticalPlayer2");
        }


        Vector3 desiredMove = (transform.forward * v) + (transform.right * h);
        desiredMove = Vector3.ClampMagnitude(desiredMove, 1f);

        Vector3 targetPos = transform.position + desiredMove * speed * Time.deltaTime;

        rb.MovePosition(targetPos);

        bool isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

        if (isGrounded == true)
        {
            isJumping = false;
        }
        if (Player == 0)
        {
            if (Input.GetButtonDown("JumpPlayer1") && isJumping == false && canJump == true)
            {
                Jump();
            }
        }
        if (Player == 1)
        {
            if (Input.GetButtonDown("JumpPlayer2") && isJumping == false && canJump == true)
            {
                Jump();
            }
        }
    }

    private void ControlsGamepadKeyboard()
    {
        if (Player == 0)
        {
            h = hinput.gamepad[Player].leftStick.horizontal;
            v = hinput.gamepad[Player].leftStick.vertical;
        }
        if (Player == 1)
        {
            h = Input.GetAxis("HorizontalPlayer2");
            v = Input.GetAxis("VerticalPlayer2");
        }


        Vector3 desiredMove = (transform.forward * v) + (transform.right * h);
        desiredMove = Vector3.ClampMagnitude(desiredMove, 1f);

        Vector3 targetPos = transform.position + desiredMove * speed * Time.deltaTime;

        rb.MovePosition(targetPos);

        bool isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

        if (isGrounded == true)
        {
            isJumping = false;
        }
        if (hinput.gamepad[Player].A.pressed && isJumping == false && canJump == true)
        {
            Jump();
        }

        if (Player == 1)
        {
            if (Input.GetButtonDown("JumpPlayer2") && isJumping == false && canJump == true)
            {
                Jump();
            }
        }
    }

    private void Controls2Gamepads()
    {
        h = hinput.gamepad[Player].leftStick.horizontal;
        v = hinput.gamepad[Player].leftStick.vertical;

        Vector3 desiredMove = (transform.forward * v) + (transform.right * h);
        desiredMove = Vector3.ClampMagnitude(desiredMove, 1f);

        Vector3 targetPos = transform.position + desiredMove * speed * Time.deltaTime;

        rb.MovePosition(targetPos);

        bool isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

        if (isGrounded == true)
        {
            isJumping = false;
        }
        if (hinput.gamepad[Player].A.pressed && isJumping == false && canJump == true)
        {
            Jump();
        }
    }

    private void Jump()
    {
        print("Press jump");
        Vector3 vel = rb.velocity;
        vel.y = powerJump;
        rb.velocity = vel;
        isJumping = true;
    }
}
