using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFire : MonoBehaviour
{
    public GameObject missilePrefab;
    public Transform spawnPoint;

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

    }

    public bool FireMissile(GameObject _missilePrefab)
    {
        GameObject usedprefab = missilePrefab;
        if (_missilePrefab != null)
        {
            usedprefab = _missilePrefab;
        }

        GameObject missile = Instantiate(usedprefab);
        missile.transform.position = spawnPoint.position;
        missile.transform.rotation = spawnPoint.rotation;

        Rigidbody rigidboy = missile.GetComponent<Rigidbody>();
        if (rigidboy == null)
        {
            return false;
        }
        rigidboy.useGravity = true;
        rigidboy.isKinematic = false;

        rigidboy.AddRelativeForce(missile.transform.forward * 1000);

        return true;
    }

}