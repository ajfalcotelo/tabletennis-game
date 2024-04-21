using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleWall : MonoBehaviour
{

    public float force = 10f;
    public float upward = 4f;

    void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Ball"))
        {

            other.GetComponent<Rigidbody>().velocity = new Vector3(0, upward, force);
        }

    }

}
