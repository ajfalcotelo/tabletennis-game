using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Transform paddle;
    private bool canFollow = true;
    private float ballOffset;


    void Start()
    {
        ballOffset = paddle.position.z - 0.5f;
    }


    void Update()
    {
        if (canFollow)
        {
            Vector3 targetPos = new Vector3(paddle.position.x, paddle.position.y, ballOffset);
            transform.position = targetPos;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            canFollow = true;
        }
    }


    public void SetCanFollow(bool value)
    {
        canFollow = value;
    }

}
