using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameManager();
            return _instance;
        }
    }

    public int player1Score;
    public int player2Score;

    public float ballSpawnTime = 10;
    public Transform ballSpawnSpot;
    public GameObject ballPrefab;
    public Transform ballContainer;
    private IEnumerator ballSpawner;

    //Used for spawning a ball if there are none
    private int numBalls;

    private bool gameover;
    public int gameoverScore = 5;

    public delegate void ScoreEventHandler(int score);
    public event ScoreEventHandler player1Scored;
    public event ScoreEventHandler player2Scored;

    public delegate void GameOverEventHandler(int winner);
    public event GameOverEventHandler gameEnded;

    private void Awake()
    {
        player1Score = 0;
        player2Score = 0;
        _instance = this;
        numBalls = 0;
        ballSpawner = SpawnTurtles();
        gameover = true;
    }

    private void Start()
    {
        gameEnded += GameOver;
    }

    private void FixedUpdate()
    {
        if (gameover)
            return;
        //Instantly spawn a ball
        //Coroutine might be in mid delay, just restart it
        //since it instantly spawns one
        if(numBalls == 0)
        {
            StopCoroutine(ballSpawner);
            StartCoroutine(ballSpawner);
        }
    }

    public void StartGame()
    {
        gameover = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public IEnumerator SpawnTurtles()
    {
        while (!gameover)
        {
            Instantiate(ballPrefab, ballSpawnSpot.position, Quaternion.identity, ballContainer);
            numBalls++;
            yield return new WaitForSeconds(ballSpawnTime);
        }
    }

    public void Player1Scored()
    {
        player1Score++;
        player1Scored?.Invoke(player1Score);
        numBalls--;

        if (player1Score >= gameoverScore)
            gameEnded?.Invoke(0);
    }

    public void Player2Scored()
    {
        player2Score++;
        player2Scored?.Invoke(player2Score);
        numBalls--;

        if (player2Score >= gameoverScore)
            gameEnded?.Invoke(1);
    }

    public void GameOver(int winner) {
        Time.timeScale = 0;
        gameover = true;
    }
}
