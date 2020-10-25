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

    private GL_RoundInternals()
    {
        this.CurrentState = RoundInternalStates.Regular;
        this.RoundWins = 0;
    }
    public bool Regular_to_KnockDown()
    {
        if (healthBar.Health > 0)
            return false;

        this.CurrentState = RoundInternalStates.KnockDown;
        ++this.RoundWins;
        return true;
    }
    public void KnockDown_to_GetUp()
    {
        this.CurrentState = RoundInternalStates.GetUp;
    }

    public void GetUp_to_Regular()
    {
        this.CurrentState = RoundInternalStates.Regular;
        this.healthBar.ResetHealth();
    }

}
