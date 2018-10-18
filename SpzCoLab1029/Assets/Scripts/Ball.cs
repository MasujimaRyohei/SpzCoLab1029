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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 refrectVec = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
        rigid2d.velocity = refrectVec;
        if(collision.gameObject.CompareTag("DeathZone"))
        {
            collision.gameObject.GetComponent<DeathZone>().CheckSide();
        }
    }

    public void Launch()
    {
        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);
        rigid2d.AddForce(new Vector2(x, y) * 500.0f);
    }
}