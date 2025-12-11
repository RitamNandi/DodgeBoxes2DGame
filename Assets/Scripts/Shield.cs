using UnityEngine;
public class Shield : MonoBehaviour
{
    public float shieldDuration = 3f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.StartCoroutine(player.ShieldBoost(shieldDuration));
            }
            Destroy(gameObject);
        }
    }
}
