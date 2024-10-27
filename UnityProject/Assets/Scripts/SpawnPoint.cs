using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private bool waitsForClickBeforeMoving = false;

    private void Start()
    {
        GameObject player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        player.GetComponent<MoveController>().waitForClickBeforeMoving = waitsForClickBeforeMoving;
    }

    private void OnEnable()
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