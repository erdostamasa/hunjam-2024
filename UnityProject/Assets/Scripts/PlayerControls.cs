using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float maxSpeed = 1f;
    [SerializeField] private float mouseDeadZone = 0f;

    void Update()
    {
        HandleTimeControls();
        HandleRestart();
    }

    private void HandleTimeControls()
    {
        float moveDirection = Input.GetAxis("Mouse X");

        float moveAmount = moveDirection * moveSpeed * Time.deltaTime;

        if (Mathf.Abs(moveAmount) < mouseDeadZone)
        {
            return;
        }

        moveAmount = Mathf.Clamp(moveAmount, -maxSpeed, maxSpeed);
        TimeManager.AddTime(moveAmount);
    }

    private void HandleRestart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TimeManager.ResetTime();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}