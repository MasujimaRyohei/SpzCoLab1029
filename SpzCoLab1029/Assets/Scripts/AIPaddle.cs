using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : Paddle
{
    [SerializeField]
    protected int interval = 30;
    private int defaultInterval;

    protected override void Awake()
    {
        base.Awake();
        defaultInterval = interval;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.ball == null)
            return;

        interval--;
        if (interval <= 0)
        {
            interval = defaultInterval;
            if (gameManager.ball.transform.position.y > transform.position.y)
                Move(1.0f);
            else
                Move(-1.0f);
        }
    }
}
