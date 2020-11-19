using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public Animator animator;
    public AttackController attackController;
    public HitCheck hitCheck;
    public Facing facing;
    public Rigidbody rb;
    public CharacterController characterController;
    public bool canMove = true;
    public bool isMoving = false;
    public bool canJump = true;
    public bool isJumping = false;
    public float thrust = 1.0f;
    public float speed = 2.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    public bool isPlayer;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    //AI values
    private float _chaseRange = 3f;
    private float _kickDistance = 1.5f;
    private float _punchDistance = 1f;
    private int rnd;
    public float _speed = 0.8f;

    public Transform _target;
    private AIState _currentState;


    void Start()
    {
        rb.AddForce(transform.forward * -thrust);
    }

    void Update()
    {
        if (isPlayer)
        {
            if (canMove)
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);
                float curSpeedX = speed * Input.GetAxisRaw("Vertical");
                float curSpeedY = speed * Input.GetAxisRaw("Horizontal");
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            }
            else if (!canMove)
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);
                moveDirection = (forward * 0) + (right * 0);
            }

            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime); 
        }
        else if (!isPlayer)
        {
            animator.transform.LookAt(_target.transform.position);
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
                        if (rnd == 0)
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
                            attackController.lowKick();
                            animator.SetBool("MoveForward", false);
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
                            attackController.straightPunch();
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

    // Update is called once per frame
    void FixedUpdate()
    {

        if (attackController.isKicking == true || attackController.isPunching == true || attackController.isBlocking == true)
        {
            canMove = false;
        }

        if (isPlayer)
        {

            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                if (canMove)
                {
                    animator.SetBool("MoveForward", true);
                    isMoving = true;
                }
                else if (!canMove)
                {
                    animator.SetBool("MoveForward", false);
                    isMoving = false;
                }
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                if (canMove)
                {
                    animator.SetBool("MoveForward", true);
                    isMoving = true;
                }
                else if (!canMove)
                {
                    animator.SetBool("MoveForward", false);
                    isMoving = false;
                }
            }
            else if (Input.GetAxisRaw("Horizontal") == 0)
            {
                if (canMove)
                {
                    animator.SetBool("MoveForward", false);
                    isMoving = false;
                }
                else if (!canMove)
                {
                    animator.SetBool("MoveForward", false);
                    isMoving = false;
                }
            }

            if (Input.GetAxisRaw("Vertical") > 0)
            {
                if (canMove)
                {
                    animator.SetBool("MoveForward", true);
                    isMoving = true;
                }
                else if (!canMove)
                {
                    animator.SetBool("MoveBackward", false);
                    isMoving = false;
                }
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                if (canMove)
                {
                    animator.SetBool("MoveBackward", true);
                    isMoving = true;
                }
                else if (!canMove)
                {
                    animator.SetBool("MoveBackward", false);
                    isMoving = false;
                }
            }
            else if (Input.GetAxisRaw("Vertical") == 0)
            {
                if (canMove)
                {
                    animator.SetBool("MoveBackward", false);
                    isMoving = false;
                }
                else if (!canMove)
                {
                    animator.SetBool("MoveBackward", false);
                    isMoving = false;
                }
            } 
        }
    }
}
