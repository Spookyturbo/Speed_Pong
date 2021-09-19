using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text player1Score;
    public TMP_Text player2Score;

    public GameObject menuPanel;

    public GameObject gameOverPanel;
    public TMP_Text gameOverText;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player1Scored += displayPlayer1Score;
        GameManager.instance.player2Scored += displayPlayer2Score;

        GameManager.instance.gameEnded += GameOverScreen;
    }

    void displayPlayer1Score(int newScore) => player1Score.SetText(newScore.ToString());
    void displayPlayer2Score(int newScore) => player2Score.SetText(newScore.ToString());

    void ToggleMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
    }

    void GameOverScreen(int winner)
    {
        gameOverPanel.SetActive(true);

        //Blue/Player1 won
        if(winner == 0)
        {
            gameOverText.text = "BLUE WINS!";
            gameOverText.color = Color.blue;
        }
        //Red/Player2 won
        else
        {
            gameOverText.text = "RED WINS!";
            gameOverText.color = Color.red;
        }
    }

}
