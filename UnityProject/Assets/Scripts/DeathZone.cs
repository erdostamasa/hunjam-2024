using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerLayer.Contains(other.gameObject.layer))
        {
            // kill player
            Destroy(other.gameObject);
            EventManager.PlayerDeath();
        }
    }
}
