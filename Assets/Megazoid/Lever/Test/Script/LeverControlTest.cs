using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class LeverControlTest : MonoBehaviour
{
    public CircularDrive _drive1 = null;
    public CircularDrive _drive2 = null;

    private LinearMapping _linearMapping1 = null;
    private LinearMapping _linearMapping2 = null;

    public float _minAngle = -45.0f;
    public float _maxAngle = 45.0f;

    // Start is called before the first frame update
    void Start()
    {
        if(_drive1 != null)
        {
            _linearMapping1 = _drive1.GetComponent<LinearMapping>();
        }

        if (_drive2 != null)
        {
            _linearMapping2 = _drive2.GetComponent<LinearMapping>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_linearMapping1 != null && _linearMapping2 != null)
        {
            Vector3 localRot = transform.localEulerAngles;
            Vector3 lowRot = new Vector3(localRot.x, _minAngle, localRot.z);
            Vector3 highRot = new Vector3(localRot.x, _maxAngle, localRot.z);
            float totalMappingValue = (_linearMapping1.value + _linearMapping2.value) / 2.0f;
            transform.localEulerAngles = Vector3.Lerp(lowRot, highRot, totalMappingValue);
        }
        else
        {
            if (_drive1 != null)
            {
                _linearMapping1 = _drive1.GetComponent<LinearMapping>();
            }

            if (_drive2 != null)
            {
                _linearMapping2 = _drive2.GetComponent<LinearMapping>();
            }
        }
    }
}
