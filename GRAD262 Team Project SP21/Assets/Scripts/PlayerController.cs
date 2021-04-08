using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float jumpForce = 250.0f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    private Rigidbody2D rbody;
    private Animator animator;
    private float vx;
    [SerializeField] private bool isGrounded = false;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        Walk();
        Jump();
    }
    void LateUpdate()
    {
        WalkOrientation();
    }

    void Walk()
    {
        vx = Input.GetAxisRaw("Horizontal");
        rbody.velocity = new Vector2(vx * moveSpeed, rbody.velocity.y);
        animator.SetBool("Walk", vx != 0);
    }

    void WalkOrientation()
    {
        if (vx == 0)
            return;

        Vector3 localScale = transform.localScale;
        bool facingRight = vx > 0;

        if (facingRight && localScale.x < 0 || !facingRight && localScale.x > 0)
            localScale.x *= -1;

        transform.localScale = localScale;
    }

    void Jump()
    {
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rbody.AddForce(new Vector2(0, jumpForce));
            animator.SetBool("Jump", true);
            isGrounded = false;
        }

        if (animator.GetBool("Jump") && isGrounded)
            animator.SetBool("Jump", false);
    }

}
