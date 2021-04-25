using UnityEngine;
using System.Collections;
using System;
using Cinemachine;

public class EnemyKnight : MonoBehaviour
{
    public HeroKnight player;
    public GameObject[] waypoints;
    public int waypointIndex = 0;
    public bool loopWaypoints = true;
    public float waitAtWaypointTime = 1.0f;
    public float moveTime = 0;
    public float moveSpeed = 4.0f;
    public bool isMoving = true;
    public float vx = 0;
    public bool isGrounded = false;
    public float attackVicinityThreshold = .6f;
    public bool inAttackVicinity = false;
    public float pursueVicinityThreshold = 5f;
    public bool inPursueVicinity = false;
    public bool playerBetweenWaypoints = false;

    private Animator animator;
    private Rigidbody2D body;
    private Sensor_HeroKnight groundSensor;

    private void Awake()
    {
        player = FindObjectOfType<HeroKnight>();
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_HeroKnight>();
    }

    void Update()
    {
        playerBetweenWaypoints = waypoints.Length == 2 
            && waypoints[0].transform.position.x < waypoints[1].transform.position.x
            && waypoints[0].transform.position.x < player.transform.position.x
            && player.transform.position.x < waypoints[1].transform.position.x;

        inAttackVicinity = playerBetweenWaypoints && Vector3.Distance(player.transform.position, transform.position) < attackVicinityThreshold;
        inPursueVicinity = playerBetweenWaypoints && Vector3.Distance(player.transform.position, transform.position) < pursueVicinityThreshold;

        //Check if character just landed on the ground
        if (!isGrounded && groundSensor.State())
        {
            isGrounded = true;
            animator.SetBool("Grounded", isGrounded);
        }

        //Check if character just started falling
        if (isGrounded && !groundSensor.State())
        {
            isGrounded = false;
            animator.SetBool("Grounded", isGrounded);
        }

        if (isGrounded)
        {
            if (inAttackVicinity)
                Attack();
            else if (inPursueVicinity)
                Pursue();
            else
                Move();
        }
    }

    void Attack()
    {
        body.velocity = new Vector2(0, 0);
        animator.SetInteger("AnimState", 0);
    }

    void Pursue()
    {
        vx = player.transform.position.x - transform.position.x;
        Flip(vx);
        animator.SetInteger("AnimState", 1);
        body.velocity = new Vector2(transform.localScale.x * moveSpeed, body.velocity.y);
    }
        
    void Move()
    {
        if (Time.time < moveTime)
            return;

        if (waypoints.Length != 0 && isMoving)
        {
            // make sure the enemy is facing the waypoint (based on previous movement)
            Flip(vx);

            // determine distance between waypoint and enemy
            vx = waypoints[waypointIndex].transform.position.x - transform.position.x;

            // if the enemy is close enough to waypoint, make it's new target the next waypoint
            if (Mathf.Abs(vx) <= 0.05f)
            {
                // At waypoint so stop moving
                body.velocity = new Vector2(0, 0);

                // increment to next index in array
                waypointIndex++;

                // reset waypoint back to 0 for looping
                if (waypointIndex >= waypoints.Length)
                {
                    if (loopWaypoints)
                        waypointIndex = 0;
                    else
                        isMoving = false;
                }

                // setup wait time at current waypoint
                moveTime = Time.time + waitAtWaypointTime;
                animator.SetInteger("AnimState", 0);
            }
            else
            {
                // enemy is moving
                animator.SetInteger("AnimState", 1);

                // Set the enemy's velocity to moveSpeed in the x direction.
                body.velocity = new Vector2(transform.localScale.x * moveSpeed, body.velocity.y);
            }
        }
    }

    // flip the enemy to face torward the direction he is moving in
    void Flip(float _vx)
    {
        // get the current scale
        Vector3 localScale = transform.localScale;

        if ((_vx > 0f) && (localScale.x < 0f))
            localScale.x *= -1;
        else if ((_vx < 0f) && (localScale.x > 0f))
            localScale.x *= -1;

        // update the scale
        transform.localScale = localScale;
    }

}
