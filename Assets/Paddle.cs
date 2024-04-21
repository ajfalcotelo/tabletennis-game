using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.WSA;

public class Paddle : MonoBehaviour
{

    bool hasServed = false;
    public float serveVelocity = 5f;
    public float forceMultiplier = 1.2f;
    public float upwardForceMultiplier = 0.3f;
    public Transform aimTarget;
    

    void OnTriggerEnter(Collider other){

        Vector3 dir = aimTarget.position - transform.position;


        if(!hasServed && other.CompareTag("Ball")){

            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
            }

            other.GetComponent<Rigidbody>().velocity = dir.normalized * serveVelocity + new Vector3(0, 0, 0);

            hasServed = true;
        }

        else if(other.CompareTag("Ball"))
        {

            dir.y = 0;

            float targetDistance = dir.magnitude;
            float initialVelocity = Mathf.Sqrt(targetDistance * Physics.gravity.magnitude / Mathf.Sin(2f * Mathf.PI / 4));
            initialVelocity *= forceMultiplier;

            float upwardForce = Mathf.Sqrt(targetDistance * Physics.gravity.magnitude);
            upwardForce *= upwardForceMultiplier;

            other.GetComponent<Rigidbody>().velocity = dir.normalized * initialVelocity + new Vector3(0, upwardForce, 0);
        }

    }

    //used for Ball.cs
    public void SetHasCollided(bool value)
    {
        hasServed = value;
    }

}
