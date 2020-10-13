using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        // move forward
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("MoveForward", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("MoveForward", false);
        }


        // move left
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("MoveForward", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("MoveForward", false);
        }

        // move right
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("MoveForward", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("MoveForward", false);
        }

        // move backward
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("MoveBackward", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("MoveBackward", false);
        }

    }
}
