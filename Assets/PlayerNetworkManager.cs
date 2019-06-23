
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkManager : NetworkBehaviour
{
    Transform myHand;
    public Transform mySphere;
    public NetworkManager networkManager;
    public IKMapperSetup ikMapper;
    public VRIKMapper vrikmapper;
    Transform trackedCalibrators;
    [SyncVar]
    int networkID;


    private void Start()
    {
        networkManager = FindObjectOfType<NetworkManager>();

        if(isServer)
            networkID = networkManager.numPlayers;

        mySphere = transform.GetChild(0);
        ikMapper = FindObjectOfType<IKMapperSetup>();
        vrikmapper = FindObjectOfType<VRIKMapper>();

        if (isLocalPlayer && localPlayerAuthority)
        {
            if (networkID == 1)
            {
                myHand = GameObject.Find("[CameraRig]").transform.Find("RightHand").transform;

            }
                
            else if (networkID == 2)
            {
                myHand = GameObject.Find("[CameraRig]").transform.Find("LeftHand").transform;

            }
               
            else if (networkID == 3)
            {
                myHand = GameObject.Find("[CameraRig]").transform.Find("RightFoot").transform;

            }
                
            else if (networkID == 4)
            {
                myHand = GameObject.Find("[CameraRig]").transform.Find("LeftFoot").transform;
            }   
        }

            if (networkID == 1)
            {

                ikMapper.rightHandTrackedObject = mySphere;
                vrikmapper.rightHandTarget = mySphere;
            }

            else if (networkID == 2)
            {

                ikMapper.leftHandTrackedObject = mySphere;
                vrikmapper.leftHandTarget = mySphere;
            }

            else if (networkID == 3)
            {

                ikMapper.rightFootTrackedObject = mySphere;
                vrikmapper.rightFootTarget = mySphere;
            }

            else if (networkID == 4)
            {
                ikMapper.leftFootTrackedObject = mySphere;
                vrikmapper.leftFootTarget = mySphere;

        }
    }

    private void Update()
    {


        if (isLocalPlayer && localPlayerAuthority)
        {
            mySphere.localPosition = myHand.localPosition;
        }
    }

    
}
