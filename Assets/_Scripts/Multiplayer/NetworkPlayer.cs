using UnityEngine;
using Photon.Pun;
using Unity.XR.CoreUtils;
using UnityEngine.XR;

public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform rightHand;
    public Transform leftHand;

    public Animator leftHandAnimator;
    public Animator rightHandAnimator;

    private PhotonView photonView;

    /// <summary>
    /// Fields will be assign to XR Rig - Main Camera; Left Controller; Right Controller;
    /// </summary>
    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;

    /// <summary>
    /// photonView - allow to synchronize player's body parts to each other
    /// rig - looking for XR Origin in Unity which means player's position
    /// [name]Rig - assign specific part of body to specific part of rig
    /// </summary>
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        XROrigin rig = FindObjectOfType<XROrigin>();
        headRig = rig.transform.Find("Camera Offset/Main Camera");
        leftHandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
        rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");

        if (photonView.IsMine)
        {
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
    }

    /// <summary>
    /// Provides that each player has its own avatar
    /// </summary>
    void Update()
    {
        if (photonView.IsMine)
        {
            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);

            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), rightHandAnimator);
        }
    }
    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    /// <summary>
    /// Method to update and synchronize current position of player's avatar.
    /// </summary>
    /// <param name="target">Current position of the player's avatar when its moving.</param>
    /// <param name="rigTransform">Position of XR Origin which will define the position of avatar.</param>
    void MapPosition(Transform target, Transform rigTransform)
    {
        target.SetPositionAndRotation(rigTransform.position, rigTransform.rotation);
    }
}
