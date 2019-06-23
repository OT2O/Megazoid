using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRIKMapperLocal : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidBody;

    private Vector3 resetPosition;
    private Quaternion resetQuaternion;

    public Transform leftHandTarget;
    public Transform rightHandTarget;
    public Transform leftFootTarget;
    public Transform rightFootTarget;

    public bool reset = false;
    public bool isKinematic = true;

    private int rightFootState = 0;
    private int leftFootState = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();

        resetPosition = transform.position;
        resetQuaternion = transform.rotation;
    }

    private void SetIK(AvatarIKGoal goal, Transform target)
    {
        animator.SetIKPositionWeight(goal, 1.0f);
        animator.SetIKPosition(goal, target.position);
        animator.SetIKRotation(goal, target.rotation);
    }

    private void OnAnimatorIK(int layerIndex)
    {
        SetIK(AvatarIKGoal.LeftHand, leftHandTarget);
        SetIK(AvatarIKGoal.RightHand, rightHandTarget);
        SetIK(AvatarIKGoal.LeftFoot, leftFootTarget);
        SetIK(AvatarIKGoal.RightFoot, rightFootTarget);
    }

    void Update()
    {
        if (reset)
        {
            isKinematic = false;
            rigidBody.isKinematic = false;

            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;

            transform.position = resetPosition;
            transform.rotation = resetQuaternion;

            reset = false;
        }

        rigidBody.isKinematic = isKinematic;
    }
}
