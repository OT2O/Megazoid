
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
        
        trackedCalibrators = GameObject.Find("TrackerCalibrators").transform;
    }

    private void Update()
    {
        rightHandSphere = trackedCalibrators.Find("RightHandSphere");
        leftHandSphere = trackedCalibrators.Find("LeftHandSphere");
        rightFootSphere = trackedCalibrators.Find("RightFootSphere");
        leftFootSphere = trackedCalibrators.Find("LeftFootSphere");

        rightHand = GameObject.Find("[CameraRig]").transform.Find("RightHand").transform;
        leftHand = GameObject.Find("[CameraRig]").transform.Find("LeftHand").transform;
        rightFoot = GameObject.Find("[CameraRig]").transform.Find("RightFoot").transform;
        leftFoot = GameObject.Find("[CameraRig]").transform.Find("LeftFoot").transform;

        if (isLocalPlayer)
        {
            if (networkID == 1)
            {
                rightHandSphere.localPosition = rightHand.localPosition;
                //Cmd_UpdateSphere(networkID, rightHandSphere.localPosition);
            }
            if (networkID == 2)
            {
                leftHandSphere.localPosition = leftHand.localPosition;
                //Cmd_UpdateSphere(networkID, leftHandSphere.localPosition);
            }
            if (networkID == 3)
            {
                rightFootSphere.localPosition = rightFoot.localPosition;
                //Cmd_UpdateSphere(networkID, rightFootSphere.localPosition);
            }
            if (networkID == 4)
            {
                leftFootSphere.localPosition = leftFoot.localPosition;
                //Cmd_UpdateSphere(networkID, leftFootSphere.localPosition);
            }
        }
    }
    [Command]
    private void Cmd_UpdateSphere(int netID, Vector3 localPos)
    {
        if (netID == 1)
        {
            rightHandSphere.localPosition = localPos;
        }
        if (netID == 2)
        {
            leftHandSphere.localPosition = localPos;
        }
        if (netID == 3)
        {
            rightFootSphere.localPosition = localPos;
        }
        if (netID == 4)
        {
            leftFootSphere.localPosition = localPos;
        }
    }
}
