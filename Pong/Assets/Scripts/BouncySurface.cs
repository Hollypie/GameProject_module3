using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

// creates physics attributes that makes the colliding objects appear to bounce from the paddles and walls.
public class BouncySurface : MonoBehaviour
{
    public enum ForceType
    {
        // Adds the bounce strength to the ball’s current speed.
        Additive,
        // Multiplies the ball’s speed by the bounce strength.
        Multiplicative,
    }

    public ForceType forceType = ForceType.Additive;
    public float bounceStrength = 0f;

    // This function increases the speed and strength of bounce of the ball so that the difficulty gradually increases as the game progresses.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            switch (forceType)
            {
                case ForceType.Additive:
                    ball.currentSpeed += bounceStrength;
                    return;

                case ForceType.Multiplicative:
                    ball.currentSpeed *= bounceStrength;
                    return;
            }
        }
    }

}