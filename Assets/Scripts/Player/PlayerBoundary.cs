using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
        transform.localScale = new Vector3(1, 1, 0);
    }

    public void ReturnBoundary()
    {
        transform.localScale = startScale;
    }
}
