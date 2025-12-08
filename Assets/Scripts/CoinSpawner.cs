using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 3f;
    public float range = 7f;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating(nameof(SpawnCoin), 1f, spawnInterval);
    }

    void SpawnCoin()
    {
        if (!GameManager.Instance.GameStarted || GameManager.gameOver) return;

        float offset = 2f;
        float spawnX = player.position.x + Random.Range(-offset, offset);
        spawnX = Mathf.Clamp(spawnX, -range, range); // Keep within horizontal bounds

        Vector3 pos = new Vector3(spawnX, transform.position.y, 0);
        Instantiate(coinPrefab, pos, Quaternion.identity);
    }
}
