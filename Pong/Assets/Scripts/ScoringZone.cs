using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]

// This logic triggers the scoring so that the player and computers scores increase when the ball reaches the goal regions. Unity Event library was used for this effect. It's generated on collision. 
public class ScoringZone : MonoBehaviour
{
    public UnityEvent scoreTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball _))
        {
            scoreTrigger.Invoke();
        }
    }

}