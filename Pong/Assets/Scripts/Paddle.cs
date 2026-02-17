using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

// This is the parent class for both the Computer and Player paddles. It is an abstract class because it is never actually instantiated on its own, but always as an inherited class. 
public abstract class Paddle : MonoBehaviour
{
    protected Rigidbody2D rb;

    // Changes how the ball bounces off the paddle depending on where it hits the paddle.
    // The further from the center of the paddle, the steeper the bounce angle.
    public float speed = 8f;

    public bool useDynamicBounce = false;

    // This code makes sure your script has a reference to the Rigidbody2D attached to the same object so you can control physics for that object later.
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Returns the paddles to the center. Used when a new game is started and when a new round has begun.
    public void ResetPosition()
    {
        rb.linearVelocity = Vector2.zero;
        rb.position = new Vector2(rb.position.x, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (useDynamicBounce && collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D ball = collision.rigidbody;
            Collider2D paddle = collision.otherCollider;

            // Gather information about the collision
            Vector2 ballDirection = ball.linearVelocity.normalized;
            Vector2 contactDistance = ball.transform.position - paddle.bounds.center;
            Vector2 surfaceNormal = collision.GetContact(0).normal;
            Vector3 rotationAxis = Vector3.Cross(Vector3.up, surfaceNormal);

            // Rotate the direction of the ball based on the contact distance
            // to make the gameplay more dynamic and interesting
            float maxBounceAngle = 75f;
            float bounceAngle = contactDistance.y / paddle.bounds.size.y * maxBounceAngle;
            ballDirection = Quaternion.AngleAxis(bounceAngle, rotationAxis) * ballDirection;

            // Re-apply the new direction to the ball
            ball.linearVelocity = ballDirection * ball.linearVelocity.magnitude;
        }
    }

}