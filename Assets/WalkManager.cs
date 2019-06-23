using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkManager : MonoBehaviour
{
    public float downKneeThreshold = 0.1f;
    public float upKneeThreshold = 0.15f;

    public Transform megazoid;

    public float forwardMovement = 1.0f;
    public float cooldownTime = 0.2f;
    public float angleIncrement = 60.0f;

    private float leftMovementCooldown = 0.0f;
    private float rightMovementCooldown = 0.0f;

    public Transform leftKneeTransform;
    public Transform rightKneeTransform;

    private bool leftKneeUp = false;
    private bool rightKneeUp = false;

    void Start()
    {
    }

    private void ApplyForce(bool left)
    {
        megazoid.position += megazoid.transform.forward * forwardMovement * Time.deltaTime;
        megazoid.rotation *= Quaternion.Euler(new Vector3(0.0f, (left ? 1.0f : -1.0f) * angleIncrement * Time.deltaTime, 0.0f));
    }

    void Update()
    {
        if(!leftKneeTransform || !rightKneeTransform)
        {
            return;
        }

        if (leftMovementCooldown > 0.0f)
        {
            ApplyForce(true);
            leftMovementCooldown -= Time.deltaTime;
        }

        if (rightMovementCooldown > 0.0f)
        {
            ApplyForce(false);
            rightMovementCooldown -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Q))
            leftMovementCooldown = cooldownTime;

        if (Input.GetKeyDown(KeyCode.W))
            rightMovementCooldown = cooldownTime;

        float la = leftKneeTransform.localPosition.y;
        float ra = rightKneeTransform.localPosition.y;

        //Debug.Log(ra + " " + downKneeThreshold + " " + upKneeThreshold + (rightKneeUp ? "rku" : "rkd"));

        if (leftKneeUp && la < downKneeThreshold)
        {
            //Debug.Log("step left");
            leftMovementCooldown = cooldownTime;
            leftKneeUp = false;
        }
        else if (la > upKneeThreshold)
        {
            leftKneeUp = true;
        }

        if (rightKneeUp && ra < downKneeThreshold)
        {
            //Debug.Log("step right");
            rightMovementCooldown = cooldownTime;
            rightKneeUp = false;
        }
        else if (ra > upKneeThreshold)
        {
            rightKneeUp = true;
        }

        //float la = GetKneeAngle(leftKneeTransform);
        //float ra = GetKneeAngle(rightKneeTransform);

        //if (leftKneeUp && la < downKneeAngleThreshold)
        //{
        //    leftKneeUp = false;
        //}
        //else if (!leftKneeUp && la > upKneeAngleThreshold)
        //{
        //    Debug.Log("step left");
        //    leftMovementCooldown = cooldownTime;
        //    leftKneeUp = true;
        //}

        //if (rightKneeUp && ra < downKneeAngleThreshold)
        //{
        //    Debug.Log("step right");
        //    rightMovementCooldown = cooldownTime;
        //    rightKneeUp = false;
        //}
        //else if (ra > upKneeAngleThreshold)
        //{
        //    rightKneeUp = true;
        //}
    }
}
