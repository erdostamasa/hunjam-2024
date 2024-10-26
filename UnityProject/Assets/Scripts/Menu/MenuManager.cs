using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private static MenuManager instance = null;

    public bool Paused;

    public GameObject MainPanel;
    public GameObject PausePanel;

    void Start()
    {
        if (PausePanel != null)
        {
            PausePanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InvokePausePanel();
        }
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


    private static int currentLevelIndex;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
        if (MainPanel.active == false)
        {
            Paused = true;
            PausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void ResumeGame()
    {
        if (MainPanel.active == false)
        {
            Paused = false;
            Time.timeScale = 1f;
            PausePanel.SetActive(false);
        }
    }

    public void ExitToMenu()
    {
        if (MainPanel.active == false)
        {
            MainPanel.SetActive(true);
            Paused = false;
            Time.timeScale = 1f;
            PausePanel.SetActive(false);
        }
    }

    public void RestartLevel()
    {
        if (MainPanel.active == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PausePanel.SetActive(false);
            Paused = false;
            Time.timeScale = 1f;
        }
    }
}