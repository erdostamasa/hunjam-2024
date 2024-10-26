using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(5, rb.linearVelocity.y);
    }
}