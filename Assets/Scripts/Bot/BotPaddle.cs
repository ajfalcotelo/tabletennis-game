using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPaddle : MonoBehaviour
{
    public float forceMultiplier = 1.2f;
    public float upwardForceMultiplier = 0.38f;
    public Collider leftCollider;
    public Collider rightCollider;
    public Transform ball;
    private Vector3 leftPaddlePos;
    private Quaternion leftPaddleRotation;
    

    void Start()
    {
        leftPaddlePos = transform.localPosition;
        leftPaddleRotation = transform.rotation;
        leftCollider.enabled = false;
    }


    public float BallLaunchSpeed(float directionMagnitude) //used in BotPaddleColliders, dynamic value, calculates based on distance between position
    {
        float initialVelocity = Mathf.Sqrt(directionMagnitude * Physics.gravity.magnitude / Mathf.Sin(2f * Mathf.PI / 4));
        initialVelocity *= forceMultiplier;
        return initialVelocity;
    }


    public float BallLaunchUplift(float directionMagnitude) //used in BotPaddleColliders, dynamic value, calculates based on distance between position
    {
        float upwardForce = Mathf.Sqrt(directionMagnitude * Physics.gravity.magnitude);
        upwardForce *= upwardForceMultiplier;
        return upwardForce;   
    }


    public void RightPaddleActive()
    {
        leftCollider.enabled = false;
        rightCollider.enabled = true;
        transform.localPosition = leftPaddlePos;
        transform.rotation = leftPaddleRotation;
    }


    public void LeftPaddleActive()
    {
        leftCollider.enabled = true;
        rightCollider.enabled = false;
        transform.localPosition = new Vector3(-leftPaddlePos.x, leftPaddlePos.y, leftPaddlePos.z);
        transform.rotation = Quaternion.Euler(-leftPaddleRotation.eulerAngles.x, leftPaddleRotation.eulerAngles.y, leftPaddleRotation.eulerAngles.z);
    }
}
