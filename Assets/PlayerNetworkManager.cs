
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkManager : NetworkBehaviour
{
    Transform myHand;
    public Transform mySphere, myOrigin;
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

        myOrigin = transform.GetChild(1);
        mySphere = transform.GetChild(0);
        ikMapper = FindObjectOfType<IKMapperSetup>();
        vrikmapper = FindObjectOfType<VRIKMapper>();

      
    }

    private void Update()
    {
        if (networkID == 1)
        {
            ikMapper.rightHandTrackedObject = mySphere;
            vrikmapper.rightHandTarget = mySphere;
            ikMapper.rightHandOrigin = myOrigin;
        }

        else if (networkID == 2)
        {
            ikMapper.leftHandTrackedObject = mySphere;
            vrikmapper.leftHandTarget = mySphere;
            ikMapper.leftHandOrigin = myOrigin;
        }

        else if (networkID == 3)
        {
            ikMapper.rightFootTrackedObject = mySphere;
            vrikmapper.rightFootTarget = mySphere;
            ikMapper.rightFootOrigin = myOrigin;
        }

        else if (networkID == 4)
        {
            ikMapper.leftFootTrackedObject = mySphere;
            vrikmapper.leftFootTarget = mySphere;
            ikMapper.leftFootOrigin = myOrigin;

        }

        if (isLocalPlayer && localPlayerAuthority)
        {
            myHand = GameObject.Find("[CameraRig]").transform.Find("Device").transform;
            myHand.GetComponent<Valve.VR.SteamVR_TrackedObject>().origin = myOrigin;
            mySphere.localPosition = myHand.localPosition;
        }
    }

    
}
