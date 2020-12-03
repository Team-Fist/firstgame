using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score hScore;
    public void Awake()
    {
        if (hScore == null)
            hScore = this;
    }
    public int GetCurrentScore()
    {
        return PlayerPrefs.GetInt("CurrentScore");
    }
    public void SetCurrentScore(int num)
    {
        PlayerPrefs.SetInt("CurrentScore", num);
    }

    public void AddScore()
    {
        int score = GetCurrentScore();
        SetCurrentScore(++score);
    }
}
