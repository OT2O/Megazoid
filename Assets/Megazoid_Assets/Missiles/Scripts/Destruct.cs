using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionForce = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(BlastAfterFrame(collision));
    }

    private IEnumerator BlastAfterFrame(Collision collision)
    {
        yield return new WaitForEndOfFrame();

        GameObject.Destroy(gameObject);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Collider[] colliders = Physics.OverlapSphere(transform.position, 50.0f);
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody rBody = colliders[i].GetComponent<Rigidbody>();
            if (rBody)
            {
                rBody.AddExplosionForce(explosionForce, transform.position, 50.0f);
            }
        }
    }
}
