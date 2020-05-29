
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Keypad_Toggle_VRDesktop_State : UdonSharpBehaviour
{
    public bool isVRComponent;
    public GameObject DesktopComponent;
    public GameObject VRComponent;
    private VRCPlayerApi _playerLocal;

    void Start()
    {
        _playerLocal = Networking.LocalPlayer;
        bool isUserInVR = _playerLocal.IsUserInVR();

        if (isUserInVR)
        {
            // VR mode

            if (isVRComponent)
            {
                Debug.Log("VR mode VR component on");
                // set the VR keypad on
                VRComponent.SetActive(true);
            }
            else
            {
                Debug.Log("VR mode desktop component off");
                // set the Desktop keypad off
                DesktopComponent.SetActive(false);
            }
        }
        else
        {
            // Desktop mode

            if (isVRComponent)
            {
                Debug.Log("Desktop mode VR component off");
                // set the VR keypad off
                VRComponent.SetActive(false);
            }
            else
            {
                Debug.Log("Desktop mode desktop component on");
                // set the Desktop keypad on
                DesktopComponent.SetActive(true);
            }
        }
    }
}
