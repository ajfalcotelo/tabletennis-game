using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class scr : MonoBehaviour
{

    public float speed = 1.5F;
    public Transform aimTarget;
    public Collider targetBoundary;
    public Collider playerBoundary;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
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
            targetBoundPos.x = Mathf.Clamp(targetBoundPos.x, targetBoundary.bounds.min.x, targetBoundary.bounds.max.x);
            targetBoundPos.z = Mathf.Clamp(targetBoundPos.z, targetBoundary.bounds.min.z, targetBoundary.bounds.max.z);
            aimTarget.position = targetBoundPos;
    
        }

    }
}
