using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 lastVelocity;
    private Rigidbody2D rigid2d;

    private void Awake()
    {
        rigid2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Launch();
    }

    void FixedUpdate()
    {
        lastVelocity = rigid2d.velocity;

        // 速度調整
        if(rigid2d.velocity.sqrMagnitude < 80.0f)
        {
            rigid2d.velocity *= 1.01f;
        }
        else if(rigid2d.velocity.sqrMagnitude > 300.0f)
        {
            rigid2d.velocity *= 0.99f;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 refrectVec = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
        rigid2d.velocity = refrectVec;
        rigid2d.velocity += new Vector2(0, Random.Range(-0.01f, 0.01f));
        if (collision.gameObject.CompareTag("Goal"))
        {
            collision.gameObject.GetComponent<Goal>().CheckSide();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Paddle"))
        {
            if (transform.position.y < collision.transform.position.y)
            {
                rigid2d.velocity = new Vector2(rigid2d.velocity.x, rigid2d.velocity.y - 1f);
            }
            else
            {
                rigid2d.velocity = new Vector2(rigid2d.velocity.x, rigid2d.velocity.y + 1f);
            }
        }
    }

    public void Launch()
    {
        rigid2d.simulated = true;
        float x = Random.Range(0, 2);
        if(x == 0)
        {
            x = -1;
        }
        else
        {
            x = 1;
        }
        float y = Random.Range(-1.0f, 1.0f);
        rigid2d.velocity = Vector2.zero;
        rigid2d.AddForce(new Vector2(x, y) * 500.0f);
    }

 
}