using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.WSA;

public class Paddle : MonoBehaviour
{
    public float serveVelocity = 5f;
    public float forceMultiplier = 1.2f;
    public float upwardForceMultiplier = 0.3f;
    public GameObject leftPaddleCollider;
    public GameObject rightPaddleCollider;
    private Collider leftCollider;
    private Collider rightCollider;
    private Vector3 originalPosition;
    private Quaternion leftRotation;
    private bool isSwitched = false;
    

    void Start()
    {
        leftCollider = leftPaddleCollider.GetComponent<Collider>();
        rightCollider = rightPaddleCollider.GetComponent<Collider>();
        originalPosition = transform.localPosition;
        leftRotation = transform.rotation;
        leftCollider.enabled = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isSwitched)
        {
            leftCollider.enabled = false;
            rightCollider.enabled = true;
            transform.localPosition = originalPosition;
            transform.rotation = leftRotation;
            isSwitched = false;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && !isSwitched)
        {
            leftCollider.enabled = true;
            rightCollider.enabled = false;
            transform.localPosition = new Vector3(-originalPosition.x, originalPosition.y, originalPosition.z);
            transform.rotation = Quaternion.Euler(-leftRotation.eulerAngles.x, leftRotation.eulerAngles.y, leftRotation.eulerAngles.z);
            isSwitched = true;
        }
    }
    

    public Vector3 ServeLaunch(Vector3 directionNormalized) //used in PaddleColliders, fixed value
    {
        Vector3 serveSpeed = directionNormalized * serveVelocity;
        return serveSpeed;
    }


    public float BallLaunchSpeed(float directionMagnitude) //used in PaddleColliders, dynamic value, calculates based on distance between position
    {
        float initialVelocity = Mathf.Sqrt(directionMagnitude * Physics.gravity.magnitude / Mathf.Sin(2f * Mathf.PI / 4));
        initialVelocity *= forceMultiplier;
        return initialVelocity;
    }


    public float BallLaunchUplift(float directionMagnitude) //used in PaddleColliders, dynamic value, calculates based on distance between position
    {
        float upwardForce = Mathf.Sqrt(directionMagnitude * Physics.gravity.magnitude);
        upwardForce *= upwardForceMultiplier;
        return upwardForce;   
    }

}
