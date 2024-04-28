using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public Transform ball;
    public Collider botBoundary;
    public Collider botFollowBoundary;
    public BotPaddle botPaddle;
    private float followOffset = 0.45f;
    private Vector3 startPosition;


    void Start()
    {
        startPosition = transform.position;
    }



    void Update()
    {
        if (true)
        {
            Vector3 targetPos;
            if (ball.position.z >= botFollowBoundary.bounds.min.x && ball.position.z <= botFollowBoundary.bounds.max.z)
            {
                targetPos = new Vector3(ball.position.x, 0, ball.position.z) + (ball.right * followOffset);
            }
            else
            {
                targetPos = new Vector3(ball.position.x, 0, startPosition.z) + (ball.right * followOffset);
            }
            
            Vector3 botBoundPos = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime); //sets to follow ball
            botBoundPos.x = Mathf.Clamp(botBoundPos.x, botBoundary.bounds.min.x, botBoundary.bounds.max.x);
            botBoundPos.z = Mathf.Clamp(botBoundPos.z, botBoundary.bounds.min.z, botBoundary.bounds.max.z);
            botBoundPos.y = transform.position.y;
            transform.position = botBoundPos; //sets bounded position

            if (transform.position.x > ball.position.x) //makes it so the bot aims to hit ball with paddle
            {
                followOffset = Mathf.Abs(followOffset);
                botPaddle.LeftPaddleActive();
            }
            else
            {
                followOffset = -Mathf.Abs(followOffset);
                botPaddle.RightPaddleActive();
            }
        }
    }
}
