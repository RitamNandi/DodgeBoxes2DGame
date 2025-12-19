using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float boostDuration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.StartCoroutine(player.SpeedBoost(boostDuration));
            }

            Destroy(gameObject);
            GameManager.usedPowerUp = true;
            Debug.Log("Power up has been marked as used, ineligible for achievement now");
        }
    }
}
