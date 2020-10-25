using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RoundStates = GL_RoundInternals.RoundInternalStates;

public class GL_WinController : MonoBehaviour
{
    #region Needed Variables
    public GL_RoundInternals Player, Opponent;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.CurrentState != RoundStates.Regular || Opponent.CurrentState != RoundStates.Regular)
            return;
        DeclareNextRound(CheckLooser());
        CheckWinner();
    }

    int CheckLooser()
    {
        if (Player.Regular_to_KnockDown())
            return 2;
        else if (Opponent.Regular_to_KnockDown())
            return 1;
        else
            return 0;

    }
    void CheckWinner()
    {
        if (Player.RoundWins == 2)
            DeclareMatchEnd();
        else if (Opponent.RoundWins == 2)
            DeclareMatchEnd();
    }

    void DeclareNextRound(int RoundWinnerIdentifier)
    {
        if (RoundWinnerIdentifier == 1)
            ;
        else if(RoundWinnerIdentifier == 2)
            ;
    }

    void DeclareMatchEnd()
    {
        ChangeScene.LoadTheLevel("MainMenu");
    }
}
