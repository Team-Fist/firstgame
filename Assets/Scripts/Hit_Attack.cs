using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Attack : MonoBehaviour
{
    public HealthBar healthBar;

    public int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Root")
            healthBar.SetHealth(damage);
    }
}
