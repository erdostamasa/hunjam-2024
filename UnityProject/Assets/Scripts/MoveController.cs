using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    private Rigidbody2D rb;

    private const float velocityMatchSpeed = 8f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Calculate the difference between the target speed and the current velocity
        float velocityDifference = moveSpeed - rb.linearVelocity.x;

        // Apply force based on the difference to adjust towards the target speed
        rb.AddForce(new Vector2(velocityDifference * velocityMatchSpeed, 0), ForceMode2D.Force);
    }
}
