using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRIKMapper : MonoBehaviour
{
    private Animator animator;
    public Transform leftHandTarget;
    public Transform rightHandTarget;
    public Transform leftFootTarget;
    public Transform rightFootTarget;

    void Start()
    {
        animator = GetComponent<Animator>();
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
    }
}
