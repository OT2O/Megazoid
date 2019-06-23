using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PulleyControlTest : MonoBehaviour
{
    public LinearDrive _drive1 = null;
    public LinearDrive _drive2 = null;
    public LinearDrive _drive3 = null;
    public LinearDrive _drive4 = null;

    private LinearMapping _linearMapping1 = null;
    private LinearMapping _linearMapping2 = null;
    private LinearMapping _linearMapping3 = null;
    private LinearMapping _linearMapping4 = null;

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

        if (_drive3 != null)
        {
            _linearMapping3 = _drive3.GetComponent<LinearMapping>();
        }

        if (_drive4 != null)
        {
            _linearMapping4 = _drive4.GetComponent<LinearMapping>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_linearMapping1 != null && _linearMapping2 != null && _linearMapping3 != null && _linearMapping4 != null)
        {
            Vector3 localRot = transform.localEulerAngles;
            Vector3 lowRot = new Vector3(localRot.x, _minAngle, localRot.z);
            Vector3 highRot = new Vector3(localRot.x, _maxAngle, localRot.z);
            Vector3 leftRot = Vector3.Lerp(lowRot, highRot, _linearMapping1.value);
            Vector3 rightRot = Vector3.Lerp(highRot, lowRot, _linearMapping2.value);
            Vector3 player1Rot = new Vector3(transform.localEulerAngles.x, leftRot.y + rightRot.y, transform.localEulerAngles.z);

            Vector3 lowRot2 = new Vector3(localRot.x, _minAngle, localRot.z);
            Vector3 highRot2 = new Vector3(localRot.x, _maxAngle, localRot.z);
            Vector3 leftRot2 = Vector3.Lerp(lowRot2, highRot2, _linearMapping3.value);
            Vector3 rightRot2 = Vector3.Lerp(highRot2, lowRot2, _linearMapping4.value);
            Vector3 player2Rot = new Vector3(transform.localEulerAngles.x, leftRot2.y + rightRot2.y, transform.localEulerAngles.z);

            transform.localEulerAngles = (player1Rot + player2Rot) / 2.0f;
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

            if (_drive3 != null)
            {
                _linearMapping3 = _drive3.GetComponent<LinearMapping>();
            }

            if (_drive4 != null)
            {
                _linearMapping4 = _drive4.GetComponent<LinearMapping>();
            }
        }
    }
}
