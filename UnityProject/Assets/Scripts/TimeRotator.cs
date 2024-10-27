using UnityEngine;

public class TimeRotator : MonoBehaviour
{
    [Header("Rotation Configuration")]
    [SerializeField] private Vector3 rotationAxis = Vector3.up; // Axis to rotate around (default is Y axis)
    [SerializeField] private float rotationSpeed = 360f; // Degrees for full rotation

    private void Update()
    {
        // Get the current time value from the TimeManager
        float currentTime = (float)TimeManager.CurrentTime; // Assuming this value is between 0 and 1

        // Calculate the total rotation based on CurrentTime
        float totalRotation = currentTime * rotationSpeed; // Total rotation in degrees

        // Create the rotation Quaternion based on the total rotation
        Quaternion targetRotation = Quaternion.Euler(rotationAxis * totalRotation); 

        // Directly set the rotation to the target rotation
        transform.localRotation = targetRotation;
    }
}
