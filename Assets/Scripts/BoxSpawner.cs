using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject boxPrefab;
    public float spawnInterval = 1.5f;
    public float range = 7f;
    public GameObject homingBoxPrefab;
    [Range(0f, 1f)] public float homingChance = 0.10f; // give it a 10% chance to spawn a homing box instead

    void Start()
    {
        InvokeRepeating(nameof(SpawnBox), 0f, spawnInterval);
    }

    void SpawnBox()
    {
        if (!GameManager.Instance.GameStarted) return;
        if (GameManager.gameOver) return;
        Vector3 pos = new Vector3(Random.Range(-range, range), transform.position.y, 0);
        GameObject prefab = Random.value < homingChance ? homingBoxPrefab : boxPrefab;
        Instantiate(prefab, pos, Quaternion.identity);
    }
}
