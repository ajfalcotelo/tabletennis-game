using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    public Transform paddle;
    private bool canFollow = true;
    private float ballOffset;
    

    private void Start()
    {
        ballOffset = paddle.position.z - 0.5f;
    }


    private void Update()
    {
        if (canFollow)
        {
            Vector3 targetPos = new Vector3(paddle.position.x, paddle.position.y, ballOffset);
            transform.position = targetPos;
        }
    }


    public void SetCanFollow(bool value)
    {
        canFollow = value;
    }
}
