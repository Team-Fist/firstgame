using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public GL_RoundInternals RoundInternals;
    public GameObject otherGuy;
    public AttackController attackController;
    public AttackController attackControllerOther;
    public MoveController moveController;
    public MoveController moveControllerOther;
    public GameObject otherHandRight;
    public GameObject otherHandLeft;
    public GameObject otherLegRight;
    public GameObject otherLegLeft;
    public Animator animator;
    public bool isHit = false;
    public HealthBar healthBar;
    public bool down = false;
    public int damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        //otherHandRight = otherGuy.transform.Find("Hand_R").gameObject;
        //otherHandLeft = otherGuy.Find("Hand_L");
        //otherLegRight = otherGuy.GetComponentInChildren<Shin_R>();
        //otherLegLeft = otherGuy.GetComponentInChildren<Shin_L>();
    }

    // Update is called once per frame
    void Update()
    {
        KnockDown();
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Reaction1"))
        {
            attackController.resetTriggers();
            isHit = true;
        }
        else
        {
            isHit = false;
        }

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("GetUp"))
        {
            attackController.resetTriggers();
            down = false;
        }
    }

    void KnockDown()
    {
        switch (RoundInternals.GetCurrentStateInt())
        {
            case 1:
                RoundInternals.KnockDown_to_GetUp();
                animator.ResetTrigger("Reaction1");
                down = true;
                animator.SetTrigger("Knockout");
                break;
            case 2:
                if (RoundInternals.GetUp_to_Regular())
                    animator.ResetTrigger("Reaction1");
                    animator.SetTrigger("GetUp");
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (true)
        {
            if (col.gameObject == otherHandLeft || col.gameObject == otherHandRight)
            {
                if (attackControllerOther.isPunching)
                {

                    isHit = true;
                    if (!attackController.isBlocking)
                    {
                        animator.SetTrigger("Reaction1");
                        healthBar.TakeDamage(damage);
                    }
                }
            }
            else if (col.gameObject == otherLegLeft || col.gameObject == otherLegRight)
            {
                if (attackControllerOther.isKicking)
                {
                    isHit = true;
                    if (!attackController.isBlocking)
                    {
                        animator.SetTrigger("Reaction1");
                        healthBar.TakeDamage(damage);
                    }
                }
            } 
        }
    }
}

