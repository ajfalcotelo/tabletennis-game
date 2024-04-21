using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    //All commented lines are code for floating ball after falling without relying on scene
    // Vector3 initialPos;
    // Paddle paddleObject;
    public bool canFollow = true;
    public Transform paddle;


    void Start()
    {
        // initialPos = transform.position;
        // paddleObject = GameObject.FindObjectOfType<Paddle>();
    }

    void Update()
    {
        if (canFollow)
        {
            Vector3 targetPos = new Vector3(paddle.position.x, paddle.position.y, transform.position.z);
            transform.position = targetPos;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            // Rigidbody rb = GetComponent<Rigidbody>();

            // rb.velocity = Vector3.zero;
            // rb.useGravity = false;
            // rb.isKinematic = true;

            // transform.position = initialPos;

            RestartGame();
        }
    }


    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void SetCanFollow(bool value)
    {
        canFollow = value;
    }

}
