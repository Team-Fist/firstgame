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
    public float speed = 0.8f;
    public Animator animator;

    //public MoveController moveController;
    public bool kickMid = false;
    public bool kickLow = false;
    public bool kickHigh = false;
    public bool punchStraight = false;
    public bool punchHook = false;
    public bool punchUpper = false;

    public Transform _target;
    private AIState _currentState;



    private void Update()
    {
        animator.transform.LookAt(_target.transform.position);
        switch (_currentState)
        {
            case AIState.Idle:
                if (Vector3.Distance(transform.position, _target.transform.position) > _chaseRange)
                {
                    transform.LookAt(_target.transform);
                    transform.Translate(Vector3.forward * Time.deltaTime * speed);
                    animator.SetBool("BackToIdle", true);
                }

                break;

            case AIState.Chase:
                {
                    if (Vector3.Distance(transform.position, _target.transform.position) < _chaseRange)
                    {
                        transform.LookAt(_target.transform);
                        transform.Translate(Vector3.forward * Time.deltaTime * speed);
                        animator.SetBool("MoveForwardAI", true);
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
                    if (rnd == 0)
                    {   
                        animator.SetTrigger("KickMidLeft");
                        animator.SetBool("MoveForwardAI", false);
                        animator.SetBool("BackToIdle",false);


                        if (Vector3.Distance(transform.position, _target.transform.position) > _kickDistance || 
                            Vector3.Distance(transform.position, _target.transform.position) < _punchDistance)
                        {
                            animator.SetBool("BackToIdle", true);
                        }
                    }
                    else
                    {
                        animator.SetTrigger("KickLowRight");
                        animator.SetBool("MoveForwardAI", false);  
                        animator.SetBool("BackToIdle", false);

                        if (Vector3.Distance(transform.position, _target.transform.position) > _kickDistance ||
                            Vector3.Distance(transform.position, _target.transform.position) < _punchDistance)
                        {
                            animator.SetBool("BackToIdle", true);   
                        }
                    }
                  

                    if (Vector3.Distance(transform.position, _target.transform.position) < _punchDistance)
                    {
                        _currentState = AIState.Punch;
                        rnd = Random.Range(0, 2);
                    }

                    if (Vector3.Distance(transform.position, _target.transform.position) > _kickDistance &&
                        Vector3.Distance(transform.position, _target.transform.position) < _chaseRange)
                    {
                        _currentState = AIState.Chase;
                    }                   

                    break;
                }
            case AIState.Punch:
                {
                    if (rnd == 0)
                    {
                        animator.SetTrigger("PunchStraightLeft");
                        animator.SetBool("MoveForwardAI", false);
                        animator.SetBool("BackToIdle", false);

                        if (Vector3.Distance(transform.position, _target.transform.position) > _punchDistance)
                        {
                            animator.SetBool("BackToIdle", true);
                        }
                    }
                    else
                    {
                        animator.SetTrigger("PunchUpperRight");
                        animator.SetBool("MoveForwardAI", false);
                        animator.SetBool("BackToIdle", false);

                        if (Vector3.Distance(transform.position, _target.transform.position) > _punchDistance)
                        {
                            animator.SetBool("BackToIdle", true);
                        }
                    }

                    if (Vector3.Distance(transform.position, _target.transform.position) > _punchDistance
                         && Vector3.Distance(transform.position, _target.transform.position) < _kickDistance
                        )
                    {
                        _currentState = AIState.Punch;
                    }

                    if (Vector3.Distance(transform.position, _target.transform.position) > _kickDistance &&
                        Vector3.Distance(transform.position, _target.transform.position) < _chaseRange)
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