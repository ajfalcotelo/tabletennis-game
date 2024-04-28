using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIn : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.SetPointToPlayer(false);
            Debug.Log(GameManager.GetPointToPlayer());
        }
    }
}
