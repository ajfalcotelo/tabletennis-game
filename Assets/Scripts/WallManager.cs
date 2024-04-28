using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallManager : MonoBehaviour
{
    public GameManager  gameManager;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("ShouldScore: " + GameManager.GetPointToPlayer());
            if (GameManager.GetPointToPlayer() == true)
            {
                gameManager.AddPlayerScore();
            }
            else if (GameManager.GetPointToPlayer() == false)
            {
                gameManager.AddBotScore();
            }

            PaddleCollider.SetHasServed(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
