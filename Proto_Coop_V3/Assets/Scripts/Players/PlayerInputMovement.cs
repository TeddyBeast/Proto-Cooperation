using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputMovement : MonoBehaviour
{
    PlayerControls controls;

    public Transform groundCheck;

    public LayerMask groundMask;

    Rigidbody rb;

    float moveFront;
    float moveBack;
    float moveLeft;
    float moveRight;

    public float speed = 7f;
    public float groundDistance = 1f;
    public float JumpHeight = 7f;
    public float gravity = -9.81f;

    public bool isGrounded;

    Vector3 InitScale;

    Vector3 velocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocity = rb.velocity;

        InitScale = transform.localScale;
    }

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Player1.Front.performed += ctx => moveFront = ctx.ReadValue<float>();
        controls.Player1.Front.canceled += ctx => moveFront = 0f;

        controls.Player1.Back.performed += ctx => moveBack = ctx.ReadValue<float>();
        controls.Player1.Back.canceled += ctx => moveBack = 0f;

        controls.Player1.Right.performed += ctx => moveRight = ctx.ReadValue<float>();
        controls.Player1.Right.canceled += ctx => moveRight = 0f;

        controls.Player1.Left.performed += ctx => moveLeft = ctx.ReadValue<float>();
        controls.Player1.Left.canceled += ctx => moveLeft = 0f;

        controls.Player1.Jump.performed += ctx => Jump();

        controls.Player1.Crouch.performed += ctx => Crouch();
        controls.Player1.Crouch.canceled += ctx => UnCrouch();
    }

    private void FixedUpdate()
    {
        float f = moveFront;
        float b = moveBack;
        float r = moveRight;
        float l = moveLeft;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 desiredMove = (transform.forward * f) + (-transform.forward * b) + (transform.right * r) + (-transform.right * l);
        desiredMove = Vector3.ClampMagnitude(desiredMove, 1f);

        Vector3 targetPos = transform.position + desiredMove * speed * Time.deltaTime;

        rb.MovePosition(targetPos);

        velocity.y += gravity * Time.deltaTime;

        rb.velocity = velocity;
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

    private void Crouch()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
    }
    
    private void UnCrouch()
    {
        transform.localScale = InitScale;
    }


    private void OnEnable()
    {
        controls.Player1.Enable();
    }

    private void OnDisable()
    {
        controls.Player1.Disable();
    }
}
