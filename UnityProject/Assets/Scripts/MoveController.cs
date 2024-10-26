using System;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] private Transform groundRaycast;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundMask;

    private bool goingRight = true;
    private Rigidbody2D rb;
    private const float velocityMatchSpeed = 8f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!Physics2D.Raycast(groundRaycast.position, Vector2.down, groundCheckDistance, groundMask))
        {
            // we are not on the ground, don't move
            return;
        }
        
        // Calculate the difference between the target speed and the current velocity
        float velocityDifference = moveSpeed - rb.linearVelocity.x;

        // Apply force based on the difference to adjust towards the target speed
        
        rb.AddForce(new Vector2(velocityDifference * velocityMatchSpeed * (goingRight ? 1 : -1), 0), ForceMode2D.Force);
    }

    public void ChangeDirection()
    {
        goingRight = !goingRight;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Debug.DrawLine(groundRaycast.position, groundRaycast.position + Vector3.down * groundCheckDistance, Color.red);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundRaycast.position, groundRaycast.position + Vector3.down * groundCheckDistance);
    }
}
