using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    public float timer = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(gameObject, timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
