using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : Paddle
{
    [SerializeField]
    private Transform ball;
    [SerializeField]
    private int interval = 30;
    private int defaultInterval;

    private void Awake()
    {
        defaultInterval = interval;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        interval--;
        if (interval <= 0)
        {
            interval = defaultInterval;
            if (ball.position.y > transform.position.y)
                Move(1.0f);
            else
                Move(-1.0f);
        }
    }
}
