using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public Animator animator;
    public AttackController attackController;
    public AI ai;
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


    void Start()
    {
        rb.AddForce(transform.forward * -thrust);
        if (!isPlayer)
        {
            ai = this.GetComponent<AI>();
        }
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
            if (!hitCheck.down)
            {
                ai.Tactics(); 
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
