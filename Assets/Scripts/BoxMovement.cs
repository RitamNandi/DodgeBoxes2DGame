using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public float baseSpeed = 2f;

    void Update()
    {
        if (!GameManager.Instance.GameStarted) return;
        if (GameManager.gameOver) return;

        float elapsed = GameManager.Instance.GetElapsedTime();
        float speedMultiplier = 1f + (elapsed / 7f); // 7 sec to double speed

        transform.Translate(Vector3.down * baseSpeed * speedMultiplier * Time.deltaTime);

        if (transform.position.y < -6f)
            Destroy(gameObject);
    }
}
