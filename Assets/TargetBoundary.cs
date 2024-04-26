using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetBoundary : MonoBehaviour
{

    public Transform afterServePos;
    public Transform aimTarget;
    private Vector3 serveAimPos;
    private bool serveBounce = false;

    void Start()
    {
        serveAimPos = transform.position;
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

    public void NewRound()
    {
        transform.position = serveAimPos;
        serveBounce = false;
    }

}
