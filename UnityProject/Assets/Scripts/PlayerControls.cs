using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float maxSpeed = 1f;
    [SerializeField] private float mouseDeadZone = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandleTimeControls();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

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