using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheckRed : MonoBehaviour
{
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
        if (healthBar.slider.value <= 0)
        {
            animator.SetTrigger("Knockout");
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
                    healthBar.SetHealth(damage);
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
                    healthBar.SetHealth(damage);
                }
            }
        }
    }
}
