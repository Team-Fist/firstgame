using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GL_RoundInternals : MonoBehaviour
{
    #region Needed Variables
    public HealthBar healthBar;
    #endregion

    #region Declarations
    public enum RoundInternalStates
    {
        Regular,
        KnockDown,
        GetUp
    }
    #endregion

    #region Public Variables
    public RoundInternalStates CurrentState { get; set; }
    public byte RoundWins { get; set; }
    #endregion

    private bool WinnerDeclared = false;

    void Start()
    {
        this.CurrentState = RoundInternalStates.Regular;
        this.RoundWins = 0;
    }

    #region State Changes
    public bool Regular_to_KnockDown()
    {
        if (healthBar.Health > 0)
            return false;

        this.CurrentState = RoundInternalStates.KnockDown;
        return true;
    }
    public void KnockDown_to_GetUp()
    {
        this.CurrentState = RoundInternalStates.GetUp;
    }

    public bool GetUp_to_Regular()
    {
        if (this.WinnerDeclared)
            return false;

        this.CurrentState = RoundInternalStates.Regular;
        return true;
    }

    public int GetCurrentStateInt()
    {
        switch (this.CurrentState)
        {
            default:
                return 0;
            case RoundInternalStates.KnockDown:
                return 1;
            case RoundInternalStates.GetUp:
                return 2;
        }
    }
    #endregion

    public void ResetHealth()
    {
        this.healthBar.ResetHealth();
    }

    public string GetRoundWinsText()
    {
        return this.RoundWins.ToString();
    }

    public bool IsMatchWinner()
    {
        return this.RoundWins == 2;
    }

    public bool RecMatchWinner()
    {
        if (this.RoundWins == 2)
        {
            Score.hScore.AddScore();
            return true;
        }
        return false;
    }

    public void DeclareWinner()
    {
        this.WinnerDeclared = true;
    }
}
