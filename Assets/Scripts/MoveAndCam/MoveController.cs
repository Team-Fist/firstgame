using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public Animator animator;
    public AttackController attackController;
    public Rigidbody rb;
    public float thrust = 5.0f;

    public float speed = 1.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;

    CharacterController characterController;
    
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;
    public bool canMove = true;
    public bool isMoving = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        attackController = GetComponent<AttackController>();
        rotation.y = transform.eulerAngles.y;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (attackController.isKicking == true || attackController.isPunching == true)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }


        //If the player is moving horizontally (left and right), and not diagonally or vertically
        //Remember: 1 is right (positive), and -1 is left (negative).
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (canMove)
            {
                animator.SetBool("MoveForward", true);
                isMoving = true;
            }
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            if (canMove)
            {
                animator.SetBool("MoveForward", true);
                isMoving = true; 
            }
        }
        else //if (Input.GetAxis("Horizontal") == 0)
        {
            if (canMove)
            {
                animator.SetBool("MoveForward", false);
                isMoving = false; 
            }
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            if (canMove)
            {
                animator.SetBool("MoveForward", true);
                isMoving = true; 
            }
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            if (canMove)
            {
                animator.SetBool("MoveBackward", true);
                isMoving = true; 
            }
        }
        else //if (Input.GetAxis("Vertical") == 0)
        {
            if (canMove)
            {
                animator.SetBool("MoveBackward", false);
                isMoving = false; 
            }
        }
    }

    void Update()
    {
        if (canMove)
        {
            if (characterController.isGrounded)
            {

                // We are grounded, so recalculate move direction based on axes
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);
                float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
                float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);


                if (Input.GetButton("Jump") && canMove)
                {
                    moveDirection.y = jumpSpeed;
                }
            } 
        }
        else
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            moveDirection = (forward * 0) + (right * 0);
        }

        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
        //rb.AddForce(moveDirection * Time.deltaTime);
    }
}
