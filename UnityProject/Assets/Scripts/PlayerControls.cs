using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    private static PlayerControls instance = null;

    public static PlayerControls Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerControls>();
            }

            if (instance == null)
            {
                GameObject gObj = new GameObject();
                gObj.name = "MenuManager";
                instance = gObj.AddComponent<PlayerControls>();
                DontDestroyOnLoad(gObj);
            }

            return instance;
        }
    }
    
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float maxSpeed = 1f;
    [SerializeField] private float mouseDeadZone = 0f;
    
    private void Start()
    {
        TimeManager.ResetTime();
    }

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


        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            ClickSoundManager.Instance.SetTargetVolume(0);
            
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

        ClickSoundManager.Instance.SetTargetVolume(moveAmount);

        TimeManager.Instance.AddTime(moveAmount);
    }

    private void HandleRestart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}