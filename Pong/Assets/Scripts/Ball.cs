using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audioSource;

    public float baseSpeed = 5f;
    public float maxSpeed = Mathf.Infinity;
    public float currentSpeed { get; set; }

    [Header("Audio")]
    public AudioClip paddleHitSound; // Drag your .wav here in Inspector
    public float paddleHitVolume = 0.7f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
    }

    private void Start()
    {
        ResetPosition();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle") && paddleHitSound != null)
        {
            audioSource.PlayOneShot(paddleHitSound, paddleHitVolume);
        }
    }

    public void ResetPosition()
    {
        rb.linearVelocity = Vector2.zero;
        rb.position = Vector2.zero;
    }

    public void AddStartingForce()
    {
        // Flip a coin to determine if the ball starts left or right
        float x = Random.value < 0.5f ? -1f : 1f;

        // Flip a coin to determine if the ball goes up or down. Set the range
        // between 0.5 -> 1.0 to ensure it does not move completely horizontal.
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f)
                                      : Random.Range(0.5f, 1f);

        // Apply the initial force and set the current speed
        Vector2 direction = new Vector2(x, y).normalized;
        rb.AddForce(direction * baseSpeed, ForceMode2D.Impulse);
        currentSpeed = baseSpeed;
    }

    private void FixedUpdate()
    {
        // Clamp the velocity of the ball to the max speed
        Vector2 direction = rb.linearVelocity.normalized;
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        rb.linearVelocity = direction * currentSpeed;
    }

}