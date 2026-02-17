using UnityEngine;
using UnityEngine.InputSystem;

// This class inherits from the abstract class of paddle.  The logic is how the user controls the paddle using the unity engines input system.
public class PlayerPaddle : Paddle
{
    private Vector2 direction;

    // Update is a special Unity method that runs once per frame. This code reads player input each frame and updates the direction variable so other parts of the script (usually FixedUpdate) know whether to move the paddle up, down, or stay still.
    private void Update()
    {
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            direction = Vector2.up;
        }
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            direction = Vector2.down;
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    // FixedUpdate() is another special Unity method. Unlike Update(), it runs at a fixed time interval (not every frame).
    private void FixedUpdate()
    {
        if (direction.sqrMagnitude != 0)
        {
            rb.AddForce(direction * speed);
        }
    }

}