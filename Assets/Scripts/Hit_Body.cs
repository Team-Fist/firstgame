using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Body : MonoBehaviour
{


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
        if (col.gameObject.name == "Hand_L" || col.gameObject.name == "Hand_R")
            Debug.Log("body");
    }
}
