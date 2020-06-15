
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Core;

public class Keypad_Button_VR : UdonSharpBehaviour
{
    public string value = "UNCONFIGURED_KEY";
    public Keypad_InputHandler targetProgram;

    public override void Interact()
    {
        Debug.Log("KeyPressed VR: " + value);

        targetProgram.inputKey = value;
        targetProgram.keyPressed();
    }
}
