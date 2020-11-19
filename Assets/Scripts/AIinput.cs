using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIinput : MonoBehaviour
{
    public AttackController attackController;
    public MoveController moveController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            attackController.isPunching = true;
            attackController.isKicking = false;
            moveController.canMove = false;
            attackController.straightPunch();
        }
    }
}
