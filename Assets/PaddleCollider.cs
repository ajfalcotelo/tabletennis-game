using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleCollider : MonoBehaviour
{
    public Paddle paddle;
    public Transform aimTarget;
    public Ball ball;
    private static bool hasServed = false;


    void OnTriggerEnter(Collider other)
    {
        Vector3 dir = aimTarget.position - paddle.transform.position;
        

        if(!hasServed && other.CompareTag("Ball")) //for Table Tennis Serves
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.isKinematic = false;
            ball.SetCanFollow(false);

            other.GetComponent<Rigidbody>().velocity = paddle.ServeLaunch(dir.normalized);
            Debug.Log("ServeLaunch: " + paddle.ServeLaunch(dir.normalized));
            hasServed = true;
        }
        else if(other.CompareTag("Ball")) //After Table Tennis Serve
        {
            dir.y = 0;
            float targetDistance = dir.magnitude;
            // ball.transform.position = new Vector3(paddle.transform.position.x, paddle.transform.position.y, paddle.transform.position.z + 0.2f);

            float ballSpeed = paddle.BallLaunchSpeed(targetDistance);
            float ballUplift = paddle.BallLaunchUplift(targetDistance);

            other.GetComponent<Rigidbody>().velocity = dir.normalized * ballSpeed + new Vector3(0, ballUplift, 0);
            Debug.Log("LaunchVelocity: " + other.GetComponent<Rigidbody>().velocity);
        }
    }


    public static void SetHasServed(bool value)
    {
        hasServed = value;
    }
}
