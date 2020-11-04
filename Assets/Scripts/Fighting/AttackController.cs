﻿using System.Collections;
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

    private void Start(){}

    public void straightPunch()
    {
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

    public void hookPunch()
    {
        if (canAttack)
        {
            if (!punchHook)
            {
                moveController.isMoving = false;
                animator.SetTrigger("PunchHookLeft");
            }
            else if (punchHook)
            {
                moveController.isMoving = false;
                animator.SetTrigger("PunchHookRight");
            }
        }
    }

    public void upperPunch()
    {
        if (canAttack)
        {
            if (!punchUpper)
            {
                moveController.isMoving = false;
                animator.SetTrigger("PunchUpperLeft");
            }
            else if (punchUpper)
            {
                moveController.isMoving = false;
                animator.SetTrigger("PunchUpperRight");
            }
        }
    }

    public void midKick()
    {
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

    void Update()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Punch_Straight_Left"))
        {
            isPunching = true;
            isKicking = false;
            punchStraight = true;
            punchHook = false;
            punchUpper = false;
            kickMid = false;
            kickLow = false;
            kickHigh = false;
            moveController.canMove = false;
        }
        else if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Punch_Straight_Right"))
        {
            isPunching = true;
            isKicking = false;
            punchStraight = false;
            punchHook = false;
            punchUpper = false;
            kickMid = false;
            kickLow = false;
            kickHigh = false;
            moveController.canMove = false;
        }
        else if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Punch_Hook_Left"))
        {
            isPunching = true;
            isKicking = false;
            punchStraight = false;
            punchHook = true;
            punchUpper = false;
            kickMid = false;
            kickLow = false;
            kickHigh = false;
            moveController.canMove = false;
        }
        else if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Punch_Hook_Right"))
        {
            isPunching = true;
            isKicking = false;
            punchStraight = false;
            punchHook = false;
            punchUpper = false;
            kickMid = false;
            kickLow = false;
            kickHigh = false;
            moveController.canMove = false;
        }
        else if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Punch_Upper_Left"))
        {
            isPunching = true;
            isKicking = false;
            punchStraight = false;
            punchHook = false;
            punchUpper = true;
            kickMid = false;
            kickLow = false;
            kickHigh = false;
            moveController.canMove = false;
        }
        else if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Punch_Upper_Right"))
        {
            isPunching = true;
            isKicking = false;
            punchStraight = false;
            punchHook = false;
            punchUpper = false;
            kickMid = false;
            kickLow = false;
            kickHigh = false;
            moveController.canMove = false;
        }
        else if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Kick_Mid_Left"))
        {
            isPunching = false;
            isKicking = true;
            punchStraight = false;
            punchHook = false;
            punchUpper = false;
            kickMid = true;
            kickLow = false;
            kickHigh = false;
            moveController.canMove = false;
        }
        else if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Kick_Mid_Right"))
        {
            isPunching = false;
            isKicking = true;
            punchStraight = false;
            punchHook = false;
            punchUpper = false;
            kickMid = false;
            kickLow = false;
            kickHigh = false;
            moveController.canMove = false;
        }
        else
        {
            isPunching = false;
            isKicking = false;
            punchStraight = false;
            punchHook = false;
            punchUpper = false;
            kickMid = false;
            kickLow = false;
            kickHigh = false;
            moveController.canMove = true;
        }
    }
}


