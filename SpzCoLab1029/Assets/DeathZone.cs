using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField]
    private Side side;

    public void CheckSide()
    {
        switch (side)
        {
            case Side.Right:
                GameManager.AddScore(Side.Left);
                break;
            case Side.Left:
                GameManager.AddScore(Side.Right);
                break;
        }
        GameManager.ResetBall();
    }
}