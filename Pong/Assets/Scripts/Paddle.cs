using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Paddle : MonoBehaviour
{
    protected Rigidbody2D rb;

    public float speed = 10f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


}