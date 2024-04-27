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
            PaddleCollider.SetHasServed(false);
            gameManager.AddPlayerScore(); //For Testing purposes
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
