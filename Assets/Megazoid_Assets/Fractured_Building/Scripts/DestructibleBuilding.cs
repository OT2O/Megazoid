﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBuilding : MonoBehaviour
{
    public GameObject destroyedVersion;
    private void OnMouseDown()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
