
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Keypad_InputHandler : UdonSharpBehaviour
{
    public UdonBehaviour displayProgram;
    public UdonBehaviour checkerProgram;
    [HideInInspector]
    public string inputKey;
    // initialize here because private strings are set to null
    // compared to public strings
    private string _dataBuffer = "";

    public void keyPressed()
    {
        if (inputKey == "OK")
        {
            checkerProgram.SetProgramVariable("attemptedPasscode", _dataBuffer);
            checkerProgram.SendCustomEvent("validatePasscode");
        }
        else if (inputKey == "CLR")
        {
            resetInput();
            checkerProgram.SendCustomEvent("logout");
        }
        // hard cap, only 8 digits long
        else if (_dataBuffer.Length < 8)
        {
            _dataBuffer += inputKey;
            displayProgram.SetProgramVariable("text", _dataBuffer);
            displayProgram.SendCustomEvent("printPassword");
        }
        else
        {
            Debug.Log("Limit reached!");
        }
        
    }

    public void resetInput()
    {
        _dataBuffer = "";
    }
}
