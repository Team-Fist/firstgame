using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacing : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Opponent;

    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        Camera.transform.LookAt(Opponent.transform);
    }
}