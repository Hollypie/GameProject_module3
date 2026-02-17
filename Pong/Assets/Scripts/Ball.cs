using UnityEngine;

// It tells Unity that any GameObject with this script must also have a Rigidbody2D component attached.
[RequireComponent(typeof(Rigidbody2D))]

// ball class that assigns the attributes of sound and various speeds. 
public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audioSource;

    public float baseSpeed = 5f;
    public float maxSpeed = Mathf.Infinity;
    public float currentSpeed { get; set; }

    [Header("Audio")]
    public AudioClip paddleHitSound;
    public float paddleHitVolume = 0.4f;

    // Method that instantiates the rb component and tells the sound to not play on load.
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

    // Begins the game again.
    private void Start()
    {
        ResetPosition();
    }

    // detects collisions so that the sound event is triggered.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle") && paddleHitSound != null)
        {
            audioSource.PlayOneShot(paddleHitSound, paddleHitVolume);
        }
    }

    // method to reset the starting position of the ball and its random direction.
    public void ResetPosition()
    {
        rb.linearVelocity = Vector2.zero;
        rb.position = Vector2.zero;
    }

    // Adds a force to the ball so that it begins moving on load.
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