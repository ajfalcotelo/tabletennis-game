using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    Vector3 initialPos;
    bool canFollow = true;
    // Paddle paddleObject;
    public Transform paddle;

    void Start()
    {
        initialPos = transform.position;
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
        if (other.CompareTag("Paddle"))
        {
            canFollow = false;
        }

        if (other.CompareTag("Wall"))
        {

            // Rigidbody rb = GetComponent<Rigidbody>();

            // rb.velocity = Vector3.zero;
            // rb.useGravity = false;
            // rb.isKinematic = true;

            // transform.position = initialPos;
            // paddleObject.SetHasCollided(false);

            RestartGame();

        }

    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
