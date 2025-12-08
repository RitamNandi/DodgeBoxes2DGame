using UnityEngine;

public class HomingBox : MonoBehaviour
{
    public float initialMoveSpeed = 3f;
    public float speedRamp = 0.2f;
    public float turnSpeed = 5f;
    public float minDistance = 0.5f;

    private Rigidbody2D rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Give initial downward velocity
        rb.linearVelocity = Vector2.down * initialMoveSpeed;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector2 directionToPlayer = ((Vector2)player.position - rb.position).normalized;

        // Turn toward the player
        Vector2 newDirection = Vector2.Lerp(
            rb.linearVelocity.normalized,
            directionToPlayer,
            turnSpeed * Time.fixedDeltaTime
        ).normalized;

        // Increase speed as time goes on
        float currentSpeed = initialMoveSpeed + (Time.timeSinceLevelLoad * speedRamp);

        // Only move if not extremely close to player
        if (Vector2.Distance(rb.position, player.position) > minDistance)
        {
            rb.linearVelocity = newDirection * currentSpeed;
        }
    }
}
