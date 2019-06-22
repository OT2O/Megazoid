using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRIKMapper : MonoBehaviour
{
    private Animator animator;
    public Transform target;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, target.position);
    }

    void Update()
    {
    }
}
