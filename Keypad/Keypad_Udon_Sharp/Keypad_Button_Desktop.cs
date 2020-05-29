
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Core;

public class Keypad_Button_Desktop : UdonSharpBehaviour
{
    public string value = "UNCONFIGURED_KEY";
    public UdonBehaviour targetProgram;

    public void OnMouseDown()
    {
        Debug.Log("KeyPressed Desktop: " + value);

        targetProgram.SetProgramVariable("inputKey", value);
        targetProgram.SendCustomEvent("keyPressed");
    }
}