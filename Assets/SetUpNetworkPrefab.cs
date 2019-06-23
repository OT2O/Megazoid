using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[ExecuteInEditMode]
public class SetUpNetworkPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform t in transform)
        {
            NetworkTransformChild n = gameObject.AddComponent<NetworkTransformChild>();
            n.target = t;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
