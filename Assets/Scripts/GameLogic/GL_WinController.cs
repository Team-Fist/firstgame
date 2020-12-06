using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GL_WinController : MonoBehaviour
{
    #region Needed Variables
    public GL_RoundInternals Player, Opponent;
    public Text RoundText, TimerText;
    #endregion

    #region Private Variables
    private byte RoundNumber = 1;
    private const float TimeInit = 60.0f;
    private float TimeNow = TimeInit;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        this.RoundText.gameObject.SetActive(true);
        this.StartCoroutine(this.Round_DeclareRound());
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Player.GetCurrentStateInt() != 0 || this.Opponent.GetCurrentStateInt() != 0)
            return;
        if (this.Round_CheckLooser() || Time_CountDown())
            this.ShowText();
    }

    #region Round Methods
    private bool Round_CheckLooser()
    {
        if (this.Player.Regular_to_KnockDown())
        {
            ++this.Opponent.RoundWins;
            return true;
        }

        else if (this.Opponent.Regular_to_KnockDown())
        {
            ++this.Player.RoundWins;
            return true;
        }
        else
            return false;

    }
    private IEnumerator Round_DeclareWinner()
    {
        this.RoundText.gameObject.SetActive(true);

        this.RoundText.text = Player.GetRoundWinsText() + " - " + Opponent.GetRoundWinsText();
        yield return new WaitForSeconds(2);

        StartCoroutine(Round_DeclareRound());
    }
    private IEnumerator Round_DeclareRound()
    {
        this.RoundText.text = "Round " + RoundNumber++;
        yield return new WaitForSeconds(2);
        this.RoundText.text = "Fight";
        yield return new WaitForSeconds(2);

        this.RoundText.gameObject.SetActive(false);
    }
    #endregion

    private bool Time_CountDown()
    {
        TimeNow -= Time.deltaTime;
        TimerText.text = Mathf.Round(TimeNow).ToString();
        if (TimeNow <= 0)
            return true;
        else
            return false;
    }

    private void ShowText()
    {
        if (this.Player.IsMatchWinner() || this.Opponent.IsMatchWinner())
        {
            this.Player.DeclareWinner();
            this.Opponent.DeclareWinner();
            this.StartCoroutine(this.DeclareMatchEnd());
        }
        else
        {
            this.Player.ResetHealth();
            this.Opponent.ResetHealth();
            this.TimeNow = TimeInit;
            this.StartCoroutine(this.Round_DeclareWinner());
        }
    }

    private IEnumerator DeclareMatchEnd()
    {
        this.RoundText.gameObject.SetActive(true);

        this.RoundText.text = this.Player.IsMatchWinner() ? "You Win" : "You Lose";
        yield return new WaitForSeconds(2);

        ChangeScene.LoadTheLevel("MainMenu");

        if (this.Player.IsMatchWinner())
            Score.hScore.AddScore();
    }
}
