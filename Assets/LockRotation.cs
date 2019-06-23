using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    private Quaternion startQuaternion;

    void Start()
    {
        startQuaternion = transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = startQuaternion;
    }
}
