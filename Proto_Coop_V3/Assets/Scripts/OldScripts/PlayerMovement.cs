using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int nbreGamepadConnected;

    public Transform groundCheck;

    public LayerMask groundMask;

    private Vector3 InitScale;

    Vector3 velocity;

    private Rigidbody rb;

    private float moveH;
    private float moveV;

    public int Player;

    public float speed = 7f;
    public float groundDistance = 1f;
    public float JumpHeight = 7f;
    public float gravity = -9.81f;

    public bool isGrounded;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<Transform>();
        velocity = rb.velocity;

        InitScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("HorizontalPlayer" + Player) != 0)
        {
            moveH = Input.GetAxis("HorizontalPlayer" + Player);
        }
        else if (Input.GetAxis("HorizontalPlayer" + Player) == 0)
        {
            moveH = 0f;
        }
        if (hinput.gamepad[Player].leftStick.horizontal != 0)
        {
            moveH = hinput.gamepad[Player].leftStick.horizontal;
        }

        if (Input.GetAxis("VerticalPlayer" + Player) != 0)
        {
            moveV = Input.GetAxis("VerticalPlayer" + Player);
        }
        else if (Input.GetAxis("HorizontalPlayer" + Player) == 0)
        {
            moveV = 0f;
        }
        if (hinput.gamepad[Player].leftStick.vertical != 0)
        {
            moveV = hinput.gamepad[Player].leftStick.vertical;
        }

        if (Input.GetButtonDown("JumpPlayer" + Player) || hinput.gamepad[Player].A.justPressed)
        {
            Jump();
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }



        Vector3 desiredMove = (transform.forward * moveV) + (transform.right * moveH);
        desiredMove = Vector3.ClampMagnitude(desiredMove, 1f);

        Vector3 targetPos = transform.position + desiredMove * speed * Time.deltaTime;

        rb.MovePosition(targetPos);

        velocity.y += gravity * Time.deltaTime;

        rb.velocity = velocity;



        if (hinput.gamepad[0].B.justPressed && Player == 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
        }
        else if (hinput.gamepad[0].B.justReleased && Player == 0)
        {
            transform.localScale = InitScale;
        }
    }


    private void Jump()
    {
        if (isGrounded)
        {
            print("Press jump");
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
            rb.velocity = velocity;
        }
    }
}
