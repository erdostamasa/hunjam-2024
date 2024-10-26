using UnityEngine;

public class CharacterRayCast : MonoBehaviour
{
    [SerializeField] private float rayDistance = 1.0f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform rayOrigin;

    void FixedUpdate()
    {
        var leftHit = Physics2D.Raycast(rayOrigin.position, Vector3.left, rayDistance, layerMask);
        var rightHit = Physics2D.Raycast(rayOrigin.position, Vector3.right, rayDistance, layerMask);


        if (leftHit.collider != null)
        {
            Debug.Log("Hit something in left direction");
        }
        if (rightHit.collider != null)
        {
            Debug.Log("Hit something in right direction");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rayOrigin.position, rayOrigin.position + Vector3.left * rayDistance);
        Gizmos.DrawLine(rayOrigin.position, rayOrigin.position + Vector3.right * rayDistance);
    }
}
