using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    protected Rigidbody2D rigid2d;
    protected virtual void Awake()
    {
        rigid2d = GetComponent<Rigidbody2D>();
    }

    protected void Move(float value)
    {
        if (value != 0)
            rigid2d.velocity = Vector2.up * value * 10;
        else
            rigid2d.velocity = Vector2.zero;
    }
}