using UnityEngine;

public class Paddle : MonoBehaviour
{
    protected GameManager gameManager;

    protected Rigidbody2D rigid2d;

    [SerializeField]
    protected float speed;

    protected virtual void Awake()
    {
        rigid2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    protected void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    protected void Move(float value)
    {
        if (value != 0)
            rigid2d.velocity = Vector2.up * value * speed;
        else
            rigid2d.velocity = Vector2.zero;
    }
}