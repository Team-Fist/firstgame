using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public Animator animator;
    public AttackController attackController;
    public Facing facing;
    public Rigidbody rb;
    public CharacterController characterController;
    public bool canMove = true;
    public bool isMoving = false;
    public bool canJump = true;
    public bool isJumping = false;


    public float thrust = 5.0f;

    public float speed = 2.0f;

    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;

    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;


    void Start()
    {
       
    }

    void Update()
    {
        if (canMove)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float curSpeedX = canMove ? speed * Input.GetAxisRaw("Vertical") : 0;
            float curSpeedY = canMove ? speed * Input.GetAxisRaw("Horizontal") : 0;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
            
        }
        else
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            moveDirection = (forward * 0) + (right * 0);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            attackController.canAttack = false;
        }
        else if (!isMoving)
        {
            attackController.canAttack = true;
        }

        if (attackController.isKicking == true || attackController.isPunching == true)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (canMove)
            {
                animator.SetBool("MoveForward", true);
                isMoving = true;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if (canMove)
            {
                animator.SetBool("MoveForward", true);
                isMoving = true;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            if (canMove)
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
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (canMove)
            {
                animator.SetBool("MoveBackward", true);
                isMoving = true;
            }
        }
        else if (Input.GetAxisRaw("Vertical") == 0)
        {
            if (canMove)
            {
                animator.SetBool("MoveBackward", false);
                isMoving = false;
            }
        }
    }
}
