using UnityEngine;

public class Goal : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private ESide side;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void CheckSide()
    {
        switch (side)
        {
            case ESide.Right:
                gameManager.AddScore(ESide.Left);
                break;
            case ESide.Left:
                gameManager.AddScore(ESide.Right);
                break;
        }

        gameManager.StartGame();
    }
}