using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public float speed = 1.5F;
    public float targetBoundOffset = 0.25f;
    public Transform aimTarget;
    public Collider targetBoundary;
    public Collider playerBoundary;
    public Vector3 startPosition;


    void Start()
    {
        startPosition = transform.position;
    }


    void Update()
    {
        float h1 = Input.GetAxisRaw("Horizontal1");
        float v1 = Input.GetAxisRaw("Vertical1");
        float h2 = Input.GetAxisRaw("Horizontal2");
        float v2 = Input.GetAxisRaw("Vertical2");

        if ( h1 != 0 || v1 != 0 )
        {
            transform.Translate( new Vector3(h1, 0, v1) * speed * Time.deltaTime);

            Vector3 playerBoundPos = transform.position;
            playerBoundPos.x = Mathf.Clamp(playerBoundPos.x, playerBoundary.bounds.min.x, playerBoundary.bounds.max.x);
            playerBoundPos.z = Mathf.Clamp(playerBoundPos.z, playerBoundary.bounds.min.z, playerBoundary.bounds.max.z);
            transform.position = playerBoundPos;
        }

        if ( h2 != 0 || v2 != 0 )
        {
            aimTarget.Translate( new Vector3(h2, 0, v2) * speed * Time.deltaTime);

            Vector3 targetBoundPos = aimTarget.position;
            targetBoundPos.x = Mathf.Clamp(targetBoundPos.x, targetBoundary.bounds.min.x + targetBoundOffset, targetBoundary.bounds.max.x - targetBoundOffset);
            targetBoundPos.z = Mathf.Clamp(targetBoundPos.z, targetBoundary.bounds.min.z + targetBoundOffset, targetBoundary.bounds.max.z - targetBoundOffset);
            aimTarget.position = targetBoundPos;
        }

    }


    public void ResetPosition()
    {
        transform.position = startPosition;
    }
}
