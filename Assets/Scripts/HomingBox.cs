using UnityEngine;

public class HomingBox : MonoBehaviour
{
    public float initialMoveSpeed = 3f;
    public float speedRamp = 0.2f;
    public float turnSpeed = 5f;
    public float minDistance = 0.5f;
    public float homingDuration = 1.5f;
    public float swayStrength = 0.3f;
    public float maxSpeed = 5f;

    private Rigidbody2D rb;
    private Transform player;
    private float homingTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        homingTimer = homingDuration;
        // Give initial downward velocity
        rb.linearVelocity = Vector2.down * initialMoveSpeed;
    }

    void Update()
    {
        if (player == null) return;
        if (homingTimer <= 0f) return;

        homingTimer -= Time.fixedDeltaTime;

        Vector2 direction = (player.position - transform.position).normalized;
        direction += Random.insideUnitCircle * swayStrength;
        direction.Normalize();

        // Gradually rotate toward target
        Vector2 newDirection = Vector2.Lerp(
            rb.linearVelocity.normalized,
            direction,
            turnSpeed * Time.fixedDeltaTime
        ).normalized;

        // Increase speed as time goes on
        float currentSpeed = Mathf.Min(initialMoveSpeed + (GameManager.Instance.GetElapsedTime() * speedRamp), maxSpeed);

        rb.linearVelocity = newDirection * currentSpeed;
    }
}
