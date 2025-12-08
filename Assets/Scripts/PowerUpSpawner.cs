using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;
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
        Instantiate(powerUpPrefab, pos, Quaternion.identity);
    }
}
