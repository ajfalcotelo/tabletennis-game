using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotIn : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.SetPointToPlayer(true);
        }
    }
}
