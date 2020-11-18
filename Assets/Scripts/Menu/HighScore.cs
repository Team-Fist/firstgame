using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text text;
    // Update is called once per frame
    void Update()
    {
        text.text = "Player Wins: " + Score.hScore.GetCurrentScore();
    }
}
