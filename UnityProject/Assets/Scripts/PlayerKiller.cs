using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    [SerializeField] private float padding = 0.1f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found in the scene.");
        }
    }

    void Update()
    {
        if (mainCamera != null && !IsInViewWithPadding(transform.position))
        {
            EventManager.PlayerDeath();
            Destroy(gameObject);
        }
    }

    // Check if the player's position is within the padded camera view
    private bool IsInViewWithPadding(Vector3 position)
    {
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(position);

        // Define the bounds with padding
        float minX = 0f - padding;
        float maxX = 1f + padding;
        float minY = 0f - padding;
        float maxY = 1f + padding;

        // Check if the player is within the padded bounds
        return viewportPoint.x >= minX && viewportPoint.x <= maxX &&
               viewportPoint.y >= minY && viewportPoint.y <= maxY &&
               viewportPoint.z > 0; // Ensure the player is in front of the camera
    }
}