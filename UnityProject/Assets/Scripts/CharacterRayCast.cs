using UnityEngine;

public class CharacterRayCast : MonoBehaviour
{
    [SerializeField] private float rayDistance = 1.0f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform rayOriginUp;
    [SerializeField] private Transform rayOriginDown;

    private MoveController moveController;

    void Start()
    {
        moveController = GetComponent<MoveController>();
    }

    void FixedUpdate()
    {
        var leftHitUp = Physics2D.Raycast(rayOriginUp.position, Vector3.left, rayDistance, layerMask);
        var leftHitDown = Physics2D.Raycast(rayOriginDown.position, Vector3.left, rayDistance, layerMask);

        var rightHitUp = Physics2D.Raycast(rayOriginUp.position, Vector3.right, rayDistance, layerMask);
        var rightHitDown = Physics2D.Raycast(rayOriginDown.position, Vector3.right, rayDistance, layerMask);

        // if (leftHitUp.collider != null)
        // {
        //     Debug.Log("Hit something in left direction");
        // }
        // if (rightHitUp.collider != null)
        // {
        //     Debug.Log("Hit something in right direction");
        // }

        if (leftHitDown.collider != null && leftHitUp.collider != null)
        {
            // hit wall on left side
            moveController.ChangeDirection();
        }

        if (rightHitDown.collider != null && rightHitUp.collider != null)
        {
            // hit wall on right side
            moveController.ChangeDirection();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rayOriginUp.position, rayOriginUp.position + Vector3.left * rayDistance);
        Gizmos.DrawLine(rayOriginUp.position, rayOriginUp.position + Vector3.right * rayDistance);

        Gizmos.DrawLine(rayOriginDown.position, rayOriginDown.position + Vector3.left * rayDistance);
        Gizmos.DrawLine(rayOriginDown.position, rayOriginDown.position + Vector3.right * rayDistance);
    }
}