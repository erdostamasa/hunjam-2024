using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float maxSpeed = 1f;
    [SerializeField] private float mouseDeadZone = 0f;

    void Update()
    {
        float moveDirection = Input.GetAxis("Mouse X");

        float moveAmount = moveDirection * moveSpeed * Time.deltaTime;

        moveAmount = Mathf.Clamp(moveAmount, -maxSpeed, maxSpeed);
        TimeManager.AddTime(moveAmount);

        Debug.Log($"movedir: {moveDirection}\n" +
                  $"moveamount: {moveAmount} \n" +
                  TimeManager.CurrentTime);
    }
}