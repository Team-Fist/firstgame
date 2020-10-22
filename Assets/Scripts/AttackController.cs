using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Animator animator;
    public MoveController moveController;
    public bool canAttack = true;
    public bool isPunching = false;
    public bool isKicking = false;
    public bool punchStraight = false;
    public bool punchHook = false;
    public bool punchUpper = false;
    public bool kickMid = false;
    public bool kickLow = false;
    public bool kickHigh = false;

    private void Start()
    {
        moveController = GetComponent<MoveController>();
    }

    void Update()
    {
        // punch straight
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            moveController.canMove = false;
            if (canAttack)
            {
                if (!punchStraight)
                {
                    moveController.isMoving = false;
                    animator.SetTrigger("PunchStraightLeft"); 
                }
                else if (punchStraight)
                {
                    moveController.isMoving = false;
                    animator.SetTrigger("PunchStraightRight");
                }
            }
        }

        /*/ punch hook
        if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKeyDown(KeyCode.W))
        {
            if (canAttack)
            {
                if (!punchStraight)
                {
                    moveController.isMoving = false;
                    moveController.canMove = false;
                    punchStraight = true;
                    animator.SetTrigger("PunchHookLeft");
                }
                else if (punchStraight)
                {
                    moveController.isMoving = false;
                    moveController.canMove = false;
                    animator.SetTrigger("PunchHookRight");
                }
            }
        }*/


        // kick mid 
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            moveController.canMove = false;
            if (canAttack)
            {
                if (!kickMid)
                {
                    moveController.isMoving = false;
                    animator.SetTrigger("KickMidLeft");
                }
                else if (kickMid)
                {
                    moveController.isMoving = false;
                    animator.SetTrigger("KickMidRight");
                }
            }
        }
    }
}


