using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float jumpForce = 250.0f;
    public bool isGrounded = false;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private float vx, vy;
    private Rigidbody2D rbody;
    private Animator animator;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, groundLayer);

        vx = Input.GetAxisRaw("Horizontal");
        rbody.velocity = new Vector2(vx * moveSpeed, rbody.velocity.y);
        animator.SetBool("Walk", vx != 0);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rbody.AddForce(new Vector2(0, jumpForce));
            animator.SetBool("Jump", true);
            isGrounded = false;
        }
        
        if (animator.GetBool("Jump") && isGrounded)
            animator.SetBool("Jump", false);
    }

    void LateUpdate()
    {
        if (vx == 0)
            return;

        Vector3 localScale = transform.localScale;
        bool facingRight = vx > 0;

        if (facingRight && localScale.x < 0 || !facingRight && localScale.x > 0)
            localScale.x *= -1;

        transform.localScale = localScale;
    }

}
