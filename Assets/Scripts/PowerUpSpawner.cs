using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public GameObject shieldPrefab;
    public float spawnInterval = 10f;
    public float range = 7f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating(nameof(SpawnPowerUp), 5f, spawnInterval);
    }

    void SpawnPowerUp()
    {
        if (!GameManager.Instance.GameStarted || GameManager.gameOver) return;

        float offset = 3f;
        float spawnX = player.position.x + Random.Range(-offset, offset);
        spawnX = Mathf.Clamp(spawnX, -range, range);

        Vector3 pos = new Vector3(spawnX, transform.position.y, 0);

        GameObject speedOrShieldPrefab = Random.value < 0.5f ? shieldPrefab : powerUpPrefab; // 50% chance for either power up
        
        Instantiate(speedOrShieldPrefab, pos, Quaternion.identity);
    }
}
