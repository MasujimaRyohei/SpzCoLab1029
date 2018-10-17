using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField]
    private Text textResult;
    [SerializeField]
    private Image panelResult;

    [SerializeField]
    private Text textScore;
    private int scoreLeft;
    private int scoreRight;

    [SerializeField]
    private Ball ball;

    private void Awake()
    {
        if (!instance)
            instance = this;

        scoreLeft = 0;
        scoreRight = 0;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void AddScore(Side side)
    {
        switch (side)
        {
            case Side.Right:
               instance. scoreRight++;
                break;
            case Side.Left:
               instance. scoreLeft++;
                break;
        }

        instance.SetScore(instance.scoreLeft, instance.scoreRight);
    }

    private void SetScore(int left, int right)
    {
        textScore.text = string.Format("{0} - {1}", left, right);
    }

    public static void ResetBall()
    {
       instance.ball.transform.position = new Vector3(2.5f, 0, 0);
    }
}