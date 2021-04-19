using System.Collections;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public float pursuitSpeed;
    public float wanderSpeed;
    float currentSpeed;

    public float directionChangeInterval;
    public bool followPlayer;

    Rigidbody2D rb2d;
    Animator animator;

    // only used when we have a target to pursue
    Transform targetTransform = null;

    Vector3 endPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentSpeed = wanderSpeed;
        rb2d = GetComponent<Rigidbody2D>();
        endPosition = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (rb2d.velocity.y != 0)
            return;

        float remainingDistance = (transform.position - endPosition).sqrMagnitude;

        if (remainingDistance > float.Epsilon)
        {
            if (rb2d != null)
            {
                animator.SetInteger("AnimState", 1);
                Vector3 newPosition = Vector3.MoveTowards(rb2d.position, endPosition, wanderSpeed * Time.deltaTime);
                rb2d.MovePosition(newPosition);
            }
        }
        else
        {
            animator.SetInteger("AnimState", 0);
        }
    }
}
