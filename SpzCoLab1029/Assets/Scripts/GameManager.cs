using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text textResult;
    [SerializeField]
    private Image panelResult;

    [SerializeField]
    private Text textScore;
    private int scoreLeft;
    private int scoreRight;

    [SerializeField]
    private Ball ballPrefab;
    [HideInInspector]
    public Ball ball;
    [SerializeField]
    private Paddle leftPaddle;
    [SerializeField]
    private Paddle rightPaddle;

    [SerializeField]
    private int winPoint;

    private void Awake()
    {
        scoreLeft = 0;
        scoreRight = 0;
    }
    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(Side side)
    {
        switch (side)
        {
            case Side.Right:
                scoreRight++;
                break;
            case Side.Left:
                scoreLeft++;
                break;
        }

        SetScore(scoreLeft, scoreRight);

    
    }

    private void SetScore(int left, int right)
    {
        textScore.text = string.Format("{0} - {1}", left, right);
    }

    public void SetBall()
    {
       ball = Instantiate(ballPrefab);
        ball.enabled = false;

        if (scoreLeft > scoreRight)
        {
            ball.transform.position = new Vector3(2.5f, 0, 0);
        }
        else
        {
            ball.transform.position = new Vector3(-2.5f, 0, 0);
        }
    }

    public void LaunchBall()
    {
        ball.enabled = true;
    }

    public void StartGame()
    {
        if (scoreLeft >= winPoint)
        {
            StartWinAnimation(Side.Left);
            return;
        }
        if (scoreRight >= winPoint)
        {
            StartWinAnimation(Side.Right);
            return;
        }

        StartCoroutine(StartGameCoroutine(3));
    }

    private IEnumerator StartGameCoroutine(int time)
    {
        SetBall();

        panelResult.enabled = true;
        // カウントダウン
        WaitForSeconds waitTime = new WaitForSeconds(1.0f);
        for (int i = time; i >= 0; i--)
        {
            textResult.text = i.ToString();
            yield return waitTime;
        }
        textResult.text = "";
        panelResult.enabled = false;
        LaunchBall();
    }

    public void StartWinAnimation(Side side)
    {
        StartCoroutine(WinAnimationCoroutine(side));
    }
    private IEnumerator WinAnimationCoroutine(Side side)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(2.0f);
        panelResult.enabled = true;
        textResult.text = "Finish!!";
        yield return waitForSeconds;
        string playerText = "";
        Color color;
        switch (side)
        {
            case Side.Right:
                color = rightPaddle.GetComponent<SpriteRenderer>().color;
                playerText = ColorUtility.ToHtmlStringRGB(color);
                playerText = "<color=#"+ playerText + ">Right</color>";
                break;
            case Side.Left:

                color = leftPaddle.GetComponent<SpriteRenderer>().color;
                playerText = ColorUtility.ToHtmlStringRGB(color);
                playerText = "<color=#"+ playerText + ">Left</color>";
                break;
        }
        textResult.text = string.Format("{0} Player \n won!!",playerText);
        yield return waitForSeconds;
        SceneManager.LoadScene("Title");

    }
}