using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed;
    public float jumpForce;
    public float jumptime;
    

    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private LayerMask m_WhatIsGround;
    const float k_GroundedRadius = .1f;

    private float jumpTimer;
    private float horizontalMove = 0;
    private bool jumping;
    public bool onGround;
    private Rigidbody2D rb;
    public Animator animator;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Input.GetKeyDown(KeyCode.W) && onGround)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumping = true;
            jumpTimer = jumptime;
        }

        if (Input.GetKey(KeyCode.W) && jumping && jumpTimer > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpTimer -= Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            jumping = false;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (rb.velocity.y < -0.1)
        {
            animator.SetBool("Falling", true);
        }
        else
        {
            animator.SetBool("Falling", false);
        }

        if (rb.velocity.y > 0.1)
        {
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }

        CheckGround();
    }

    private void FixedUpdate()
    {
        
        rb.velocity = new Vector2(horizontalMove * Time.fixedDeltaTime, rb.velocity.y);
    }


    void CheckGround()
    {
        onGround = Physics2D.OverlapCircle(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
    }
}
