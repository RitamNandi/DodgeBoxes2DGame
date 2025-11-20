using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject boxPrefab;
    public float spawnInterval = 1.5f;
    public float range = 7f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnBox), 0f, spawnInterval);
    }

    void SpawnBox()
    {
        if (GameManager.gameOver) return;
        Vector3 pos = new Vector3(Random.Range(-range, range), transform.position.y, 0);
        Instantiate(boxPrefab, pos, Quaternion.identity);
    }
}
