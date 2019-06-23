using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IKMapperSetup : MonoBehaviour
{
    public Transform leftHandOrigin;
    public Transform rightHandOrigin;
    public Transform leftFootOrigin;
    public Transform rightFootOrigin;

    public Transform leftHandTrackedObject;
    public Transform rightHandTrackedObject;
    public Transform leftFootTrackedObject;
    public Transform rightFootTrackedObject;

    public Vector3 leftHandOriginOffset;
    public Vector3 rightHandOriginOffset;
    public Vector3 leftFootOriginOffset;
    public Vector3 rightFootOriginOffset;

    private void PopulateDropdown(Dropdown dropdown)
    {
        for (int i = 0; i < 16; ++i)
            dropdown.options.Add(new Dropdown.OptionData(i.ToString()));
    }

    private void DropdownValueChanged(Dropdown dropdown, Transform trackedObject)
    {
      //  trackedObject.index = (Valve.VR.SteamVR_TrackedObject.EIndex)dropdown.value;
    }

    private void Calibrate(Transform origin, Transform trackedObject, Vector3 offset)
    {
        origin.position = -trackedObject.position + offset;
        //origin.rotation = Quaternion.Inverse(trackedObject.transform.rotation);
    }

    private void CalibrateAll()
    {
        Calibrate(leftHandOrigin, leftHandTrackedObject, leftHandOriginOffset);
        Calibrate(rightHandOrigin, rightHandTrackedObject, rightHandOriginOffset);
        Calibrate(leftFootOrigin, leftFootTrackedObject, leftFootOriginOffset);
        Calibrate(rightFootOrigin, rightFootTrackedObject, rightFootOriginOffset);
    }

    void Start()
    {
        Dropdown rightHandDropdown = transform.Find("RightHandDropdown").GetComponent<Dropdown>();
        Dropdown leftHandDropdown = transform.Find("LeftHandDropdown").GetComponent<Dropdown>();
        Dropdown rightFootDropdown = transform.Find("RightFootDropdown").GetComponent<Dropdown>();
        Dropdown leftFootDropdown = transform.Find("LeftFootDropdown").GetComponent<Dropdown>();

        leftHandDropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(leftHandDropdown, leftHandTrackedObject); });
        rightHandDropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(rightHandDropdown, rightHandTrackedObject); });
        leftFootDropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(leftFootDropdown, leftFootTrackedObject); });
        rightFootDropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(rightFootDropdown, rightFootTrackedObject); });

        PopulateDropdown(rightHandDropdown);
        PopulateDropdown(leftHandDropdown);
        PopulateDropdown(rightFootDropdown);
        PopulateDropdown(leftFootDropdown);

        //rightHandTrackedObject.index = (Valve.VR.SteamVR_TrackedObject.EIndex)3;
        //leftHandTrackedObject.index = (Valve.VR.SteamVR_TrackedObject.EIndex)4;
        //rightFootTrackedObject.index = (Valve.VR.SteamVR_TrackedObject.EIndex)4;
        //leftFootTrackedObject.index = (Valve.VR.SteamVR_TrackedObject.EIndex)3;

        Button rightHandButton = transform.Find("RightHandCalibrate").GetComponent<Button>();
        Button leftHandButton = transform.Find("LeftHandCalibrate").GetComponent<Button>();
        Button rightFootButton = transform.Find("RightFootCalibrate").GetComponent<Button>();
        Button leftFootButton = transform.Find("LeftFootCalibrate").GetComponent<Button>();
        Button calibrateAllButton = transform.Find("CalibrateAll").GetComponent<Button>();

        leftHandButton.onClick.AddListener(delegate { Calibrate(leftHandOrigin, leftHandTrackedObject, leftHandOriginOffset); });
        rightHandButton.onClick.AddListener(delegate { Calibrate(rightHandOrigin, rightHandTrackedObject, rightHandOriginOffset); });
        leftFootButton.onClick.AddListener(delegate { Calibrate(leftFootOrigin, leftFootTrackedObject, leftFootOriginOffset); });
        rightFootButton.onClick.AddListener(delegate { Calibrate(rightFootOrigin, rightFootTrackedObject, rightFootOriginOffset); });
        calibrateAllButton.onClick.AddListener(delegate { CalibrateAll(); });
    }

    void Update()
    {
    }
}
