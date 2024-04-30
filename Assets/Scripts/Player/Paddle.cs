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
    public float upwardMultiplier = 0.38f;
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    private Collider leftCollider;
    private Collider rightCollider;
    private Vector3 leftPaddlePos;
    private Quaternion leftPaddleRotation;
    private bool isSwitched = false;
    

    void Start()
    {
        leftCollider = leftPaddle.GetComponent<Collider>();
        rightCollider = rightPaddle.GetComponent<Collider>();
        leftPaddlePos = transform.localPosition;
        leftPaddleRotation = transform.rotation;
        leftCollider.enabled = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isSwitched)
        {
            leftCollider.enabled = false;
            rightCollider.enabled = true;
            transform.localPosition = leftPaddlePos;
            transform.rotation = leftPaddleRotation;
            isSwitched = false;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && !isSwitched)
        {
            leftCollider.enabled = true;
            rightCollider.enabled = false;
            transform.localPosition = new Vector3(-leftPaddlePos.x, leftPaddlePos.y, leftPaddlePos.z);
            transform.rotation = Quaternion.Euler(-leftPaddleRotation.eulerAngles.x, leftPaddleRotation.eulerAngles.y, leftPaddleRotation.eulerAngles.z);
            isSwitched = true;
        }
    }
    

    public Vector3 ServeLaunchSpeed(Vector3 dirNormalized) //used in PaddleColliders, fixed value
    {
        Vector3 serveSpeed = dirNormalized * serveVelocity;
        return serveSpeed;
    }


    public float BallLaunchSpeed(float dirMagnitude) //used in PaddleColliders, dynamic value, calculates based on distance between position
    {
        float initialVelocity = Mathf.Sqrt(dirMagnitude * Physics.gravity.magnitude / Mathf.Sin(2f * Mathf.PI / 4));
        initialVelocity *= forceMultiplier;
        return initialVelocity;
    }


    public float BallLaunchUplift(float dirMagnitude) //used in PaddleColliders, dynamic value, calculates based on distance between position
    {
        float upwardForce = Mathf.Sqrt(dirMagnitude * Physics.gravity.magnitude);
        upwardForce *= upwardMultiplier;
        return upwardForce;   
    }
}
