using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuManager.Instance.Paused = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void returnToStart()
    {

        SceneManager.LoadScene(0);
    }
}
