using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheckRed : MonoBehaviour
{
    public GL_RoundInternals RoundInternals;
    public GameObject blueGuy;
    public AttackController attackControllerBlue;
    public Animator animator;
    public bool isHit = false;
    public HealthBar healthBar;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        blueGuy = UnityEngine.GameObject.FindWithTag("Player");
        attackControllerBlue = blueGuy.GetComponent<AttackController>();
    }

    // Update is called once per frame
    void Update()
    {
        KnockDown();
    }

    void KnockDown()
    {
        switch (RoundInternals.GetCurrentStateInt())
        {
            case 1:
                RoundInternals.KnockDown_to_GetUp();
                animator.SetTrigger("Knockout");
                break;
            case 2:
                if(RoundInternals.GetUp_to_Regular())
                    animator.SetTrigger("GetUp");
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "BlueHand")
        {
            if (attackControllerBlue.isPunching)
            {
                if (!isHit)
                {
                    isHit = true;
                    animator.SetTrigger("Reaction1");
                    healthBar.TakeDamage(damage);
                }
            }
        }
        else if (col.gameObject.tag == "BlueLeg")
        {
            if (attackControllerBlue.isKicking)
            {
                if (!isHit)
                {
                    isHit = true;
                    animator.SetTrigger("Reaction1");
                    healthBar.TakeDamage(damage);
                }
            }
        }
    }
}
