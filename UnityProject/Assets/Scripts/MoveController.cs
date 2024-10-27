using System;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [HideInInspector] public bool waitForClickBeforeMoving = true;
    [SerializeField] private bool canMove = false;

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] private Transform groundRaycast1;
    [SerializeField] private Transform groundRaycast2;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float minTimeBetweenTurns = 0.5f;

    [SerializeField] private Animator animator;

    [SerializeField] private float maxVerticalSpeed = 50f;

    [SerializeField] private float maxHorizontalSpeed = 50f;


    private bool goingRight = true;
    private Rigidbody2D rb;

    private float timeSinceLastTurn = 0f;

    void Start()
    {
        animator.SetBool("Grounded", true);
        rb = GetComponent<Rigidbody2D>();

        if (!waitForClickBeforeMoving)
        {
            canMove = true;
        }
    }

    void Update()
    {
        if (waitForClickBeforeMoving && !canMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                canMove = true;
            }
        }

        if (!canMove)
        {
            return;
        }

        timeSinceLastTurn += Time.deltaTime;

        animator.SetFloat("MoveSpeed", Math.Abs(rb.linearVelocity.x));

        if (goingRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }

        rb.linearVelocity = new Vector2(Math.Min(rb.linearVelocity.x, maxHorizontalSpeed),
            Math.Min(rb.linearVelocity.y, maxVerticalSpeed));
        if (!Physics2D.Raycast(groundRaycast1.position, Vector2.down, groundCheckDistance, groundMask) &&
            !Physics2D.Raycast(groundRaycast2.position, Vector2.down, groundCheckDistance, groundMask))
        {
            animator.SetBool("Grounded", false);
            return;
        }

        animator.SetBool("Grounded", true);

        // Calculate the difference between the target speed and the current velocity
        // float velocityDifference = moveSpeed - Math.Abs(rb.linearVelocity.x);

        // // Apply force based on the difference to adjust towards the target speed

        // rb.AddForce(new Vector2(velocityDifference * velocityMatchSpeed * (goingRight ? 1 : -1), 0), ForceMode2D.Force);

        rb.linearVelocity = new Vector2(moveSpeed * (goingRight ? 1 : -1), rb.linearVelocity.y);
    }

    public void ChangeDirection()
    {
        if (timeSinceLastTurn >= minTimeBetweenTurns)
        {
            timeSinceLastTurn = 0;
            goingRight = !goingRight;
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Debug.DrawLine(groundRaycast.position, groundRaycast.position + Vector3.down * groundCheckDistance, Color.red);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundRaycast1.position, groundRaycast1.position + Vector3.down * groundCheckDistance);
        Gizmos.DrawLine(groundRaycast2.position, groundRaycast2.position + Vector3.down * groundCheckDistance);
    }
}