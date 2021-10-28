using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenuManager : MonoBehaviour
{
    public Slider ballAccelSlider;
    public Slider powershotSlider;
    public Slider playerSpeed;
    public TMP_InputField ballSpawnTime;
    public TMP_InputField wallHealth;
    public TMP_InputField winningScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
        //Load from settings
        ballAccelSlider.value = SettingsManager.BallAcceleration;
        powershotSlider.value = SettingsManager.PowershotAcceleration;
        playerSpeed.value = SettingsManager.PlayerSpeed;
        ballSpawnTime.text = SettingsManager.BallSpawnRate.ToString();
        wallHealth.text = SettingsManager.WallHealth.ToString();
        winningScore.text = SettingsManager.WinningScore.ToString();
    }

    public void SaveAndExit()
    {
        //write to settings
        SettingsManager.BallAcceleration = ballAccelSlider.value;
        SettingsManager.PowershotAcceleration = powershotSlider.value;
        SettingsManager.PlayerSpeed = playerSpeed.value;
        SettingsManager.BallSpawnRate = int.Parse(ballSpawnTime.text);
        SettingsManager.WallHealth = int.Parse(wallHealth.text);
        SettingsManager.WinningScore = int.Parse(winningScore.text);

        GameManager.instance.Restart();
    }
}
