using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ServeTarget : MonoBehaviour
{

    public Transform afterServePos;
    public Transform aimTarget;
    private bool serveBounce = false;

    void OnTriggerEnter(Collider other)
    {

        if(!serveBounce && other.CompareTag("Ball"))
        {
            aimTarget.localPosition = new Vector3(0, 0, 0);
            transform.position = afterServePos.position;
            serveBounce = true;
        }

    }

}
