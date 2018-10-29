using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    protected GameManager gameManager;

    protected Rigidbody2D rigid2d;

    [SerializeField]
    protected float speed;

    [SerializeField] protected ESide side;
    
    private string keyName;

    [SerializeField] private bool isAI;
    
 [SerializeField]
    protected int aiInterval = 30;
    private int defaultInterval;

    protected virtual void Awake()
    {
        rigid2d = GetComponent<Rigidbody2D>();

        if (isAI)
        {
            defaultInterval = aiInterval;
        }
        else
        {
            switch (side)
            {
                case ESide.Right:
                    keyName = "RightPaddle";
                    break;
                case ESide.Left:
                    keyName = "LeftPaddle";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (isAI)
        {
            if (gameManager.ball == null)
            {
                return;
            }

            aiInterval--;
            if (aiInterval <= 0)
            {
                aiInterval = defaultInterval;
                if (gameManager.ball.transform.position.y > transform.position.y)
                {
                    Move(1.0f);
                }
                else
                {
                    Move(-1.0f);
                }
            }
        }
        else
        {
            Move(Input.GetAxisRaw(keyName));
        }

    }
    
    protected void Move(float value)
    {
        if (value != 0)
        {
            rigid2d.velocity = Vector2.up * value * speed;
        }
        else
        {
            rigid2d.velocity = Vector2.zero;
        }
    }
}