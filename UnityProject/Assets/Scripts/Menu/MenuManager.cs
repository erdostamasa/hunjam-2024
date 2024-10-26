using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MainPanel; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        MainPanel.SetActive(false);   
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    static public void CallLevel(int level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Additive);
    }
}
