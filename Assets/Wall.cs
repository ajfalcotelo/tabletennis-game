using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Ball ball;
    public TargetBoundary targetBoundary;
    public Player player;


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            rb.isKinematic = true;

            // ball.SetCanFollow(true);
            targetBoundary.ResetPosition();
            // player.ResetPosition();
            PaddleCollider.SetHasServed(false);
        }
    }
}
