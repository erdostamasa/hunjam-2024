using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float maxSpeed = 1f;
    [SerializeField] private float mouseDeadZone = 0f;
    
    [Header("Click sounds")]
    [SerializeField] private AudioSource source;
    [SerializeField] private float minVolume = 0f;
    [SerializeField] private float maxVolume = 1f;
    [SerializeField] private float volumeChangeSpeed = 1f;
    [SerializeField] private float targetSpeedScalar = 10f;
    private float targetVolume = 0;

    void Update()
    {
        if (MenuManager.Instance.Paused)
        {
            return;
        }
        
        if (Input.GetMouseButton(0))
        {
            HandleTimeControls();
        }
        else
        {
            targetVolume = Mathf.Lerp(targetVolume, 0, Time.deltaTime * volumeChangeSpeed);
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
        HandleClickSound();
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

        targetVolume = Mathf.Abs(moveAmount) * targetSpeedScalar;
        
        TimeManager.AddTime(moveAmount);
        
    }

    private void HandleClickSound()
    {
        source.volume = Mathf.Lerp(source.volume, targetVolume, Time.deltaTime * volumeChangeSpeed);
        Debug.Log($"volume: {source.volume} targetolume: {targetVolume}");
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