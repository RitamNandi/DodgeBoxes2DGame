using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        if (!GameManager.Instance.GameStarted) return;
        if (GameManager.gameOver) return;

        float x = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * x * speed * Time.deltaTime);
        // player moves left/right with arrow keys or A/D keys
    }
}
