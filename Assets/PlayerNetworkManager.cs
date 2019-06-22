
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkManager : NetworkBehaviour
{
    Transform rightHand, leftHand, rightFoot, leftFoot;
    public Transform rightHandSphere, leftHandSphere, rightFootSphere, leftFootSphere;


    private void Start()
    {
        
        rightHand = transform.Find("RightHand").transform;
        leftHand = transform.Find("LeftHand").transform;
        rightFoot = transform.Find("RightFoot").transform;
        leftFoot = transform.Find("LeftFoot").transform;

        if (isLocalPlayer)
        {

            Transform trackedCalibrators = GameObject.Find("TrackerCalibrators").transform;
            rightHandSphere = trackedCalibrators.Find("RightHandSphere").transform;
            leftHandSphere = trackedCalibrators.Find("LeftHandSphere").transform;
            rightFootSphere = trackedCalibrators.Find("RightFootSphere").transform;
            leftFootSphere = trackedCalibrators.Find("LeftFootSphere").transform;
        }

 
    }

    private void Update()
    {
        if (isLocalPlayer && !isServer)
        {
            if (rightHandSphere )
            {
                rightHand.localPosition = rightHandSphere.localPosition;
                rightHand.localEulerAngles = rightHandSphere.localEulerAngles;
            }

            if (leftHandSphere)
            {
                leftHand.localPosition = leftHandSphere.localPosition;
                leftHand.localEulerAngles = leftHandSphere.localEulerAngles;
            }

            if (rightFootSphere)
            {
                rightFoot.localPosition = rightFootSphere.localPosition;
                rightFoot.localEulerAngles = rightFootSphere.localEulerAngles;
            }

            if (leftFootSphere)
            {
                leftFoot.localPosition = leftFootSphere.localPosition;
                leftFoot.localEulerAngles = leftFootSphere.localEulerAngles;
            }
        }
        else if (isServer)
        {
            if (rightHandSphere)
            {
                rightHandSphere.localPosition = rightHand.localPosition;
                rightHandSphere.localEulerAngles = rightHand.localEulerAngles;
            }

            if (leftHandSphere)
            {
                leftHandSphere.localPosition = leftHand.localPosition;
                leftHandSphere.localEulerAngles = leftHand.localEulerAngles;
            }

            if (rightFootSphere)
            {
                rightFootSphere.localPosition = rightFoot.localPosition;
                rightFootSphere.localEulerAngles = rightFoot.localEulerAngles;
            }

            if (leftFootSphere)
            {
                leftFootSphere.localPosition = leftFoot.localPosition;
                leftFootSphere.localEulerAngles = leftFoot.localEulerAngles;
            }
        }
    }
}
