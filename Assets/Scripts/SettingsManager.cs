using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SettingsManager
{
    public static float BallAcceleration
    {
        get { return PlayerPrefs.GetFloat("ballAccel", 0.1f); }
        set { PlayerPrefs.SetFloat("ballAccel", value); PlayerPrefs.Save(); }
    }

    public static int BallSpawnRate
    {
        get { return PlayerPrefs.GetInt("ballSpawnRate", 10); }
        set { PlayerPrefs.SetInt("ballSpawnRate", value); PlayerPrefs.Save(); }
    }

    public static float PlayerSpeed
    {
        get { return PlayerPrefs.GetFloat("playerSpeed", 10); }
        set { PlayerPrefs.SetFloat("playerSpeed", value); PlayerPrefs.Save(); }
    }

    public static int WallHealth
    {
        get { return PlayerPrefs.GetInt("wallHealth", 10); }
        set { PlayerPrefs.SetInt("wallHealth", value); PlayerPrefs.Save(); }
    }

    public static int WinningScore
    {
        get { return PlayerPrefs.GetInt("winningScore", 5); }
        set { PlayerPrefs.SetInt("winningScore", value); PlayerPrefs.Save(); }
    }

    public static float PowershotAcceleration
    {
        get { return PlayerPrefs.GetFloat("powershotAccel", 0.5f); }
        set { PlayerPrefs.SetFloat("powershotAccel", value); PlayerPrefs.Save(); }
    }
}
