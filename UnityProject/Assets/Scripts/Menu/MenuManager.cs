using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private static MenuManager instance = null;

    public bool Paused;

    public GameObject MainPanel;
    public GameObject PausePanel;
    public GameObject CreditsPanel;
    public GameObject ExitButton;

    private static int currentLevelIndex;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (PausePanel != null)
        {
            PausePanel.SetActive(false);
        }

        if (ExitButton != null && Application.platform != RuntimePlatform.WindowsPlayer)
        {
            ExitButton.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InvokePausePanel();
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.S))
        {
            NextLevel();
        }
#endif
    }

    public static MenuManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MenuManager>();
            }

            if (instance == null)
            {
                GameObject gObj = new GameObject();
                gObj.name = "MenuManager";
                instance = gObj.AddComponent<MenuManager>();
                DontDestroyOnLoad(gObj);
            }

            return instance;
        }
    }


    public void StartGame()
    {
        MainPanel.SetActive(false);
        NextLevel();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void InvokePausePanel()
    {
        if (!MainPanel.activeSelf)
        {
            Paused = true;
            PausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void ResumeGame()
    {
        Paused = false;
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    public void ExitToMenu()
    {
        MainPanel.SetActive(true);
        Paused = false;
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PausePanel.SetActive(false);
        Paused = false;
        Time.timeScale = 1f;
    }

    public void InvokeCreditPanel()
    {
        CreditsPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}