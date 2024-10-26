using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour
{

    [SerializeField] private LayerMask playerMask;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerMask.Contains(other.gameObject.layer))
        {
            // Player hit collider, switch to next level
            MenuManager.Instance.NextLevel();
        }
    }
}
