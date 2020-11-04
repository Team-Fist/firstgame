using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public AttackController attackController;
    public MoveController moveController;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attackController.straightPunch();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            attackController.midKick();
        }
    }
}
