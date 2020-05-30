
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

    public void KeyPressProxy()
    {
        // if you are using UI code buttons, sending a UI button OnClick()
        // event to UdonBehavior.SendCustomEvent of the same object, using OnMouseDown
        // as the function, doesn't work.
        //
        // This method is here to be used as a proxy for the UI buttons or any other use-case
        OnMouseDown();
    }
}
