using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D controller;
    public float speed = 6f;
    public float jumpForce = 15;
    private float moveInput;
    private bool isGrounded_down;
    private bool isGrounded_left;
    private bool isGrounded_right;
    public Transform groundChek_down;
    public Transform groundChek_left;
    public Transform groundChek_right;
    public float checkRadius;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        isGrounded_down = Physics2D.OverlapCircle(groundChek_down.position, checkRadius, whatIsGround);
        isGrounded_left = Physics2D.OverlapCircle(groundChek_left.position, checkRadius, whatIsGround);
        isGrounded_right = Physics2D.OverlapCircle(groundChek_right.position, checkRadius, whatIsGround);

        if ((isGrounded_down || isGrounded_left || isGrounded_right) && Input.GetKeyDown(KeyCode.Space))
        {
            controller.velocity = Vector2.up * jumpForce;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        controller.velocity = new Vector2(moveInput * speed, controller.velocity.y);
    }
}
