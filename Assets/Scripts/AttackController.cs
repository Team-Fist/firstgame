using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        // punch straight left
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("PunchStraightLeft");
        }

        // kick mid left
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetTrigger("KickMidLeft");
        }
    }
}


