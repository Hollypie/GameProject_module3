using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPaddle : Paddle
{
    private Vector2 direction;

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

    private void FixedUpdate()
    {
        if (direction.sqrMagnitude != 0)
        {
            rb.AddForce(direction * speed);
        }
    }

}