using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddleCollider : MonoBehaviour
{
    public Paddle paddle;
    public Transform aimTarget;
    public Ball ball;
    private bool hasServed = false;


    void OnTriggerEnter(Collider other)
    {
        Vector3 dir = aimTarget.position - paddle.transform.position;
        

        if(!hasServed && other.CompareTag("Ball")) //for Table Tennis Serves
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
            }

            other.GetComponent<Rigidbody>().velocity = paddle.ServeLaunch(dir.normalized);
            Debug.Log("ServeLaunch: " + paddle.ServeLaunch(dir.normalized));
            ball.SetCanFollow(false);
            hasServed = true;
        }
        else if(other.CompareTag("Ball")) //After Table Tennis Serve
        {
            dir.y = 0;
            float targetDistance = dir.magnitude;        

            float ballSpeed = paddle.BallLaunchSpeed(targetDistance);
            float ballUplift = paddle.BallLaunchUplift(targetDistance);

            other.GetComponent<Rigidbody>().velocity = dir.normalized * ballSpeed + new Vector3(0, ballUplift, 0);
            Debug.Log("LaunchVelocity: " + other.GetComponent<Rigidbody>().velocity);
        }
    }
}
