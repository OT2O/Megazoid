using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DestructibleBuilding : NetworkBehaviour
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
            GameObject building = Instantiate(destroyedVersion, transform.position, transform.rotation);
            NetworkServer.Spawn(building);
            Destroy(gameObject);
        }

    }
}
