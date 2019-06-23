using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBuilding : MonoBehaviour
{
    public GameObject destroyedVersion;
    

    //private void OnMouseDown() 
    //{
    //    Instantiate(destroyedVersion, transform.position, transform.rotation);
    //    Destroy(gameObject);
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.impulse.magnitude > 15.0f)
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
