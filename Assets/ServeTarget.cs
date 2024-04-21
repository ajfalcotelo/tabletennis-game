using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeTarget : MonoBehaviour
{

    public Transform afterServePos;
    bool hasServed = false;

    void OnTriggerEnter(Collider other)
    {

        if(!hasServed && other.CompareTag("Ball"))
        {
            transform.position = afterServePos.position;
            hasServed = true;
        }

    }

}
