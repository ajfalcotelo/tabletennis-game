using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPaddleCollider : MonoBehaviour
{
    public BotPaddle botPaddle;
    public Transform botAimTarget;


    void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Ball"))
        {
            Vector3 dir = botAimTarget.position - botPaddle.transform.position;

            dir.y = 0;
            float targetDistance = dir.magnitude;        

            float ballSpeed = botPaddle.BallLaunchSpeed(targetDistance);
            float ballUplift = botPaddle.BallLaunchUplift(targetDistance);

            other.GetComponent<Rigidbody>().velocity = dir.normalized * ballSpeed + new Vector3(0, ballUplift, 0);
        }
    }
}
