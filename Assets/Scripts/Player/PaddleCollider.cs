using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleCollider : MonoBehaviour
{
    public float cooldownDuration = 1.2f;
    public Paddle paddle;
    public Transform aimTarget;
    public Ball ball;
    public PlayerBoundary playerBoundary;
    private static bool hasServed = false;
    private bool keyActive;
    private bool canBallLaunch = false;
    private float lastTriggerTime;


    void Update()
    {
        if (canBallLaunch)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!hasServed)
                {
                    ServeLaunch();
                    hasServed = true;
                }
                else if (Time.time >= (lastTriggerTime + cooldownDuration))
                {
                    playerBoundary.ReturnBoundary();
                    BallLaunch();
                }

                lastTriggerTime = Time.time;
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            canBallLaunch = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            canBallLaunch = false;
        }
    }


    private void ServeLaunch()
    {
        Vector3 dir = aimTarget.position - paddle.transform.position;
        ball.SetCanFollow(false);

        GameObject ballObject = GameObject.FindGameObjectWithTag("Ball");
        Rigidbody rb = ballObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.velocity = paddle.ServeLaunchSpeed(dir.normalized);
    }


    private void BallLaunch()
    {
        GameObject ballObject = GameObject.FindGameObjectWithTag("Ball");
        Rigidbody rb = ballObject.GetComponent<Rigidbody>();

        Vector3 dir = aimTarget.position - paddle.transform.position;
        dir.y = 0;
        float targetDistance = dir.magnitude;        
        float ballSpeed = paddle.BallLaunchSpeed(targetDistance);
        float ballUplift = paddle.BallLaunchUplift(targetDistance);

        rb.velocity = dir.normalized * ballSpeed + new Vector3(0, ballUplift, 0);
    }


    public static void SetHasServed(bool value)
    {
        hasServed = value;
    }

    
    public static bool GetHasServed()
    {
        return hasServed;
    }
}
