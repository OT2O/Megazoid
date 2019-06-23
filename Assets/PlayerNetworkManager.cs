
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkManager : NetworkBehaviour
{
    Transform myHand;
    public Transform mySphere, myOrigin;
    public NetworkManager networkManager;
    public IKMapperSetupLocal ikMapper;
    public VRIKMapperLocal vrikmapper;
    Transform trackedCalibrators;
    SpawnPoint[] spawnPoints;
    RocketFire[] rocketFire;

    [SyncVar]
    int networkID;


    private void Start()
    {
        rocketFire = FindObjectsOfType<RocketFire>();
        spawnPoints = FindObjectsOfType<SpawnPoint>();

        networkManager = FindObjectOfType<NetworkManager>();

        if(isServer)
            networkID = networkManager.numPlayers;

        myOrigin = transform.GetChild(1);
        mySphere = transform.GetChild(0);
        ikMapper = FindObjectOfType<IKMapperSetupLocal>();
        vrikmapper = FindObjectOfType<VRIKMapperLocal>();

      
    }

    private void Update()
    {
        GameObject cameraRig = GameObject.Find("[CameraRig]");
        if (isServer)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                CmdReset();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                CmdDoFireOne();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CmdDoFireOther();
            }
        }
        

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
            foreach (SpawnPoint sp in spawnPoints)
            {
                if (sp.spawnPointID == networkID)
                {
                    transform.parent = sp.transform;
                    transform.localPosition = Vector3.zero;
                    transform.localEulerAngles = Vector3.zero;


                    cameraRig.transform.parent = sp.transform;
                    cameraRig.transform.localPosition = Vector3.zero;
                    cameraRig.transform.localEulerAngles = Vector3.zero;
                }
            }

            //myHand = cameraRig.transform.Find("Device").transform;
            //myHand.GetComponent<Valve.VR.SteamVR_TrackedObject>().origin = myOrigin;
            //mySphere.localPosition = myHand.localPosition;
        }
    }

    [Command]
    void CmdDoFireOne()
    {
        rocketFire[0].FireMissile();
    }

    [Command]
    void CmdDoFireOther()
    {
        rocketFire[1].FireMissile();
    }

    [Command]
    void CmdReset()
    {
        vrikmapper.reset = true;
    }
}
