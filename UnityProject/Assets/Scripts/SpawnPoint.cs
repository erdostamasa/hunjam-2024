using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    private void Start()
    {
        EventManager.onPlayerDeath += SpawnPlayer;
    }

    private void OnDestroy()
    {
        EventManager.onPlayerDeath -= SpawnPlayer;
    }

    private void SpawnPlayer()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
