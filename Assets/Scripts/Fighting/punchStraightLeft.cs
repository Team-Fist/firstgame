using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchStraightLeft : StateMachineBehaviour
{
    public GameObject player;
    public MoveController moveController;
    public AttackController attackController;
    public Animator animator;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = UnityEngine.GameObject.FindWithTag("Player");
        moveController = player.GetComponent<MoveController>();
        attackController = player.GetComponent<AttackController>();
        animator = player.GetComponent<Animator>();
        attackController.isPunching = true;
        attackController.punchStraight = true;
        moveController.canMove = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //     
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveController.canMove = true;
        attackController.isPunching = false;
        attackController.punchStraight = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
