using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Facing : MonoBehaviour
{
    public GameObject Self;
    public GameObject Other;
    public bool facing = true;

    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        if (facing)
        {
            Self.transform.LookAt(Other.transform);
        }
        else
        {
            Self.transform.LookAt(Self.transform);
        }
    }
}