using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public AttackController attackController;
    public MoveController moveController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !attackController.isBlocking)
        {
            attackController.isPunching = true;
            attackController.isKicking = false;
            moveController.canMove = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && !attackController.isBlocking)
        {
            attackController.isPunching = false;
            attackController.isKicking = true;
            moveController.canMove = false;
        }

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetAxisRaw("Vertical") > 0)
            {
                moveController.canMove = false;
                attackController.hookPunch();
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetAxisRaw("Vertical") < 0)
            {
                moveController.canMove = false;
                attackController.upperPunch();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetAxisRaw("Vertical") == 0)
        {
            moveController.canMove = false;
            attackController.straightPunch();
        }

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && Input.GetAxisRaw("Vertical") > 0)
            {
                moveController.canMove = false;
                attackController.lowKick();
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1) && Input.GetAxisRaw("Vertical") < 0)
            {
                moveController.canMove = false;
                attackController.highKick();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && Input.GetAxisRaw("Vertical") == 0)
        {
            moveController.canMove = false;
            attackController.midKick();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            attackController.startBlock();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            attackController.endBlock();
        }
    }
}
