using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RocketFire : MonoBehaviour
{
    public GameObject missilePrefab;
    public Transform spawnPoint;

    public KeyCode fireKey;

    // Start is called before the first frame update
    private void Awake()
    {

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(fireKey))
            FireMissile();
    }

    public bool FireMissile()
    {

        
        GameObject missile = Instantiate(missilePrefab);
        missile.transform.localScale *= 0.1f;

        //NetworkServer.Spawn(missile);

        missile.transform.position = spawnPoint.position;
        missile.transform.rotation = spawnPoint.rotation;

        Rigidbody rigidboy = missile.GetComponent<Rigidbody>();
        if (rigidboy == null)
        {
            return false;
        }
        rigidboy.useGravity = true;
        rigidboy.isKinematic = false;

        rigidboy.AddRelativeForce(missile.transform.forward * 5000);

        return true;
    }

}