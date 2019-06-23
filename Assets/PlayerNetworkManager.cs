
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkManager : NetworkBehaviour
{
    Transform rightHand, leftHand, rightFoot, leftFoot;
    public Transform rightHandSphere, leftHandSphere, rightFootSphere, leftFootSphere;
    public NetworkManager networkManager;
    Transform trackedCalibrators;
    [SyncVar]
    int networkID;


    private void Start()
    {
        networkManager = FindObjectOfType<NetworkManager>();

        if(isServer)
            networkID = networkManager.numPlayers;

        rightHand = transform.Find("RightHand").transform;
        leftHand = transform.Find("LeftHand").transform;
        rightFoot = transform.Find("RightFoot").transform;
        leftFoot = transform.Find("LeftFoot").transform;
        trackedCalibrators = GameObject.Find("TrackerCalibrators").transform;
    }

    private void Update()
    {

        switch (networkID)
        {
            case 1:
                rightHandSphere = trackedCalibrators.Find("RightHandSphere").transform;
                rightHandSphere.localPosition = rightHand.localPosition;
                rightHandSphere.localEulerAngles = rightHand.localEulerAngles;

                if (isLocalPlayer)
                {
                    rightHand.localPosition = rightHandSphere.localPosition;
                    rightHand.localEulerAngles = rightHandSphere.localEulerAngles;
                }

                break;
            case 2:
                leftHandSphere = trackedCalibrators.Find("LeftHandSphere").transform;
                leftHandSphere.localPosition = leftHand.localPosition;
                leftHandSphere.localEulerAngles = leftHand.localEulerAngles;

                if (isLocalPlayer)
                {
                    leftHand.localPosition = leftHandSphere.localPosition;
                    leftHand.localEulerAngles = leftHandSphere.localEulerAngles;
                }
                break;
            case 3:
                rightFootSphere = trackedCalibrators.Find("RightFootSphere").transform;
                rightFootSphere.localPosition = rightFoot.localPosition;
                rightFootSphere.localEulerAngles = rightFoot.localEulerAngles;

                if (isLocalPlayer)
                {
                    rightFoot.localPosition = rightFootSphere.localPosition;
                    rightFoot.localEulerAngles = rightFootSphere.localEulerAngles;
                }
                break;
            case 4:
                leftFootSphere = trackedCalibrators.Find("LeftFootSphere").transform;
                leftFootSphere.localPosition = leftFoot.localPosition;
                leftFootSphere.localEulerAngles = leftFoot.localEulerAngles;

                if (isLocalPlayer)
                {
                    leftFoot.localPosition = leftFootSphere.localPosition;
                    leftFoot.localEulerAngles = leftFootSphere.localEulerAngles;
                }
                break;
        }

        //if (isLocalPlayer && !isServer)
        //{
        //    if (rightHandSphere)
        //    {
        //        rightHand.localPosition = rightHandSphere.localPosition;
        //        rightHand.localEulerAngles = rightHandSphere.localEulerAngles;
        //    }

        //    if (leftHandSphere)
        //    {
        //        leftHand.localPosition = leftHandSphere.localPosition;
        //        leftHand.localEulerAngles = leftHandSphere.localEulerAngles;
        //    }

        //    if (rightFootSphere)
        //    {
        //        rightFoot.localPosition = rightFootSphere.localPosition;
        //        rightFoot.localEulerAngles = rightFootSphere.localEulerAngles;
        //    }

        //    if (leftFootSphere)
        //    {
        //        leftFoot.localPosition = leftFootSphere.localPosition;
        //        leftFoot.localEulerAngles = leftFootSphere.localEulerAngles;
        //    }
        //}
        //else if (isServer)
        //{
        //    if (rightHandSphere)
        //    {
        //        rightHandSphere.localPosition = rightHand.localPosition;
        //        rightHandSphere.localEulerAngles = rightHand.localEulerAngles;
        //    }

        //    if (leftHandSphere)
        //    {
        //        leftHandSphere.localPosition = leftHand.localPosition;
        //        leftHandSphere.localEulerAngles = leftHand.localEulerAngles;
        //    }

        //    if (rightFootSphere)
        //    {
        //        rightFootSphere.localPosition = rightFoot.localPosition;
        //        rightFootSphere.localEulerAngles = rightFoot.localEulerAngles;
        //    }

        //    if (leftFootSphere)
        //    {
        //        leftFootSphere.localPosition = leftFoot.localPosition;
        //        leftFootSphere.localEulerAngles = leftFoot.localEulerAngles;
        //    }
        //}
    }
}
