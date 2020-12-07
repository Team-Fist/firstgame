using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
//using Random = System.Random;
public class AI : MonoBehaviour
{
    private float _chaseRange = 3f;
    private float _kickDistance = 1.5f;
    private float _punchDistance = 1f;
    private int rnd;
    public float _speed = 0.8f;
    public Animator animator;
    public AttackController attackController;
    public HitCheck hitCheck;
    public Transform _target;
    private AIState _currentState;

    public void Tactics()
    {
        //animator.transform.LookAt(_target.transform.position);
        switch (_currentState)
        {
            case AIState.Idle:
                if (Vector3.Distance(transform.position, _target.transform.position) > _chaseRange)
                {
                    transform.LookAt(_target.transform);
                    transform.Translate(Vector3.forward * Time.deltaTime * _speed);
                    animator.SetBool("BackToIdle", true);
                }

                break;

            case AIState.Chase:
                {
                    if (Vector3.Distance(transform.position, _target.transform.position) < _chaseRange)
                    {
                        transform.LookAt(_target.transform);
                        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
                        animator.SetBool("MoveForward", true);
                    }

                    if (Vector3.Distance(transform.position, _target.transform.position) <= _kickDistance)
                    {
                        _currentState = AIState.Kick;
                        rnd = Random.Range(0, 2);

                        //Debug.Log(rnd);
                    }
                    break;
                }
            case AIState.Kick:
                {
                    if (rnd == 0 && attackController.canAttack)
                    {
                        attackController.midKick();
                        animator.SetBool("MoveForward", false);
                        animator.SetBool("BackToIdle", false);


                        if (Vector3.Distance(transform.position, _target.transform.position) > _kickDistance ||
                            Vector3.Distance(transform.position, _target.transform.position) < _punchDistance)
                        {
                            animator.SetBool("BackToIdle", true);
                        }
                    }
                    else
                    {
                        attackController.highKick();
                        animator.SetBool("MoveForward", false);
                        animator.SetBool("BackToIdle", false);

                        if (Vector3.Distance(transform.position, _target.transform.position) > _kickDistance ||
                            Vector3.Distance(transform.position, _target.transform.position) < _punchDistance)
                        {
                            animator.SetBool("BackToIdle", true);
                        }
                    }


                    if (Vector3.Distance(transform.position, _target.transform.position) < _punchDistance && attackController.canAttack)
                    {
                        _currentState = AIState.Punch;
                        rnd = Random.Range(0, 2);
                    }

                    if (Vector3.Distance(transform.position, _target.transform.position) > _kickDistance &&
                        Vector3.Distance(transform.position, _target.transform.position) < _chaseRange && attackController.canAttack)
                    {
                        _currentState = AIState.Chase;
                    }

                    break;
                }
            case AIState.Punch:
                {
                    if (rnd == 0 && attackController.canAttack)
                    {
                        attackController.hookPunch();
                        animator.SetBool("MoveForward", false);
                        animator.SetBool("BackToIdle", false);

                        if (Vector3.Distance(transform.position, _target.transform.position) > _punchDistance)
                        {
                            animator.SetBool("BackToIdle", true);
                        }
                    }
                    else
                    {
                        attackController.upperPunch();
                        animator.SetBool("MoveForward", false);
                        animator.SetBool("BackToIdle", false);

                        if (Vector3.Distance(transform.position, _target.transform.position) > _punchDistance)
                        {
                            animator.SetBool("BackToIdle", true);
                        }
                    }

                    if (Vector3.Distance(transform.position, _target.transform.position) > _punchDistance
                         && Vector3.Distance(transform.position, _target.transform.position) < _kickDistance
                        && attackController.canAttack)
                    {
                        _currentState = AIState.Punch;
                    }

                    if (Vector3.Distance(transform.position, _target.transform.position) > _kickDistance &&
                        Vector3.Distance(transform.position, _target.transform.position) < _chaseRange && attackController.canAttack)
                    {
                        _currentState = AIState.Chase;
                        rnd = Random.Range(0, 2);
                    }


                    break;
                }
        }
    }
}

public enum AIState
{
    Chase,
    Kick,
    Punch,
    Idle
}