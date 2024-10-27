using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalManager : MonoBehaviour
{
    void Start()
    {
        MenuManager.Instance.Paused = true;
    }

    public void returnToStart()
    {
        // destroy main menu so its not duplicated at the start
        Destroy(FindFirstObjectByType<MenuManager>().gameObject);
        SceneManager.LoadScene(0);
    }
}
