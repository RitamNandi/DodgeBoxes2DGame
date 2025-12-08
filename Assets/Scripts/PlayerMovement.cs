using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private float originalSpeed;
    private bool boosted = false;    
    void Start()
    {
        originalSpeed = speed;   
    }

    void Update()
    {
        if (!GameManager.Instance.GameStarted || GameManager.gameOver) return;

        float x = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * x * speed * Time.deltaTime);
        // player moves left/right with arrow keys or A/D keys
    }
    public IEnumerator SpeedBoost(float duration)
    {
        if (!boosted)
        {
            boosted = true;
            speed *= 2f;
        }

        yield return new WaitForSeconds(duration);

        boosted = false;
        speed = originalSpeed;
    }
}
