
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Core;

public class Keypad_Button : UdonSharpBehaviour
{
    public string value = "UNCONFIGURED_KEY";
    public UdonBehaviour targetProgram;
    private VRCPlayerApi _playerLocal = Networking.LocalPlayer;

    public override void Interact()
    {
        bool isUserInVR = _playerLocal.IsUserInVR();
        if (isUserInVR)
        {
            KeyPress();
        }
    }

    public void OnMouseDown()
    {
        KeyPress();
    }

    private void KeyPress()
    {
        Debug.Log("KeyPressed: " + value);

        targetProgram.SetProgramVariable("inputKey", value);
        targetProgram.SendCustomEvent("keyPressed");
    }
}
