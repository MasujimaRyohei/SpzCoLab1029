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
        if(rigid2d.velocity.sqrMagnitude < 80.0f)
        {
            rigid2d.velocity *= 1.01f;
        }
        rigid2d.AddForce(-transform.position.normalized * 0.1f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 refrectVec = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
        rigid2d.velocity = refrectVec;
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            collision.gameObject.GetComponent<DeathZone>().CheckSide();
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
        if(collision.gameObject.CompareTag("Gimmick"))
        {
            rigid2d.velocity *= 1.01f;
        }
        rigid2d.velocity *= 1.005f;

    }

    public void Launch()
    {
        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);
        rigid2d.velocity = Vector2.zero;
        rigid2d.AddForce(new Vector2(x, y) * 500.0f);
    }
}