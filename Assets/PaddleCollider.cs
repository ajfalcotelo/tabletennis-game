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
        Debug.Log(hasServed);
        if(other.CompareTag("Ball"))
        {
            Vector3 dir = aimTarget.position - paddle.transform.position;

            if(!hasServed)
            {
                ball.SetCanFollow(false);

                Rigidbody rb = other.GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.isKinematic = false;

                other.GetComponent<Rigidbody>().velocity = paddle.ServeLaunch(dir.normalized);
                Debug.Log("ServeLaunch: " + paddle.ServeLaunch(dir.normalized) + " hasServed: " + hasServed);   
                hasServed = true;
            }
            else
            {
                dir.y = 0;
                float targetDistance = dir.magnitude;        

                float ballSpeed = paddle.BallLaunchSpeed(targetDistance);
                float ballUplift = paddle.BallLaunchUplift(targetDistance);

                other.GetComponent<Rigidbody>().velocity = dir.normalized * ballSpeed + new Vector3(0, ballUplift, 0);
                Debug.Log("LaunchVelocity: " + other.GetComponent<Rigidbody>().velocity + " hasServed: " + hasServed);
            }
        }
    }


    public static void SetHasServed(bool value)
    {
        hasServed = value;
    }
}
