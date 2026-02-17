using UnityEngine;

// Our Computer paddle inherits from the paddle class. This code creates a basic AI for the user to play against.  The paddle returns to center when the ball is moving away from it to give it a more human like behavior rather than just going towards the movement of the ball all the time. Multiplies the ball’s speed by the bounce strength.
public class ComputerPaddle : Paddle
{
    public Rigidbody2D ball;
    private void FixedUpdate()
    {
        // Check if the ball is moving towards the paddle (positive x velocity)
        // or away from the paddle (negative x velocity)
        if (ball.linearVelocity.x > 0f)
        {
            // Move the paddle in the direction of the ball to track it
            if (ball.position.y > rb.position.y)
            {
                rb.AddForce(Vector2.up * speed);
            }
            else if (ball.position.y < rb.position.y)
            {
                rb.AddForce(Vector2.down * speed);
            }
        }
        else
        {
            // Move towards the center of the field and idle there until the
            // ball starts coming towards the paddle again
            if (rb.position.y > 0f)
            {
                rb.AddForce(Vector2.down * speed);
            }
            else if (rb.position.y < 0f)
            {
                rb.AddForce(Vector2.up * speed);
            }
        }
    }
}
