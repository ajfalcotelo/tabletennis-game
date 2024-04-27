using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetBoundary : MonoBehaviour
{

    public Transform afterServePos;
    public Transform aimTarget;
    private bool serveBounce = false;
    private Vector3 startPosition;


    void Start()
    {
        startPosition = transform.position;
    }
    void OnTriggerEnter(Collider other)
    {
        if(!serveBounce && other.CompareTag("Ball"))
        {
            aimTarget.localPosition = new Vector3(0, 0, 0);
            transform.position = afterServePos.position;
            serveBounce = true;
        }
    }


    public void ResetPosition()
    {
        transform.position = startPosition;
        serveBounce = false;
    }

}
