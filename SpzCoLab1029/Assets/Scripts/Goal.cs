using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private Side side;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void CheckSide()
    {
        switch (side)
        {
            case Side.Right:
                gameManager.AddScore(Side.Left);
                break;
            case Side.Left:
                gameManager.AddScore(Side.Right);
                break;
        }

        gameManager.StartGame();
    }
}