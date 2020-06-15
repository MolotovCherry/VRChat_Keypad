
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Keypad_InputHandler : UdonSharpBehaviour
{
    public Keypad_Display displayProgram;
    public Keypad_SolutionChecker checkerProgram;
    [HideInInspector]
    public string inputKey;
    // initialize here because private strings are set to null
    // compared to public strings
    private string _dataBuffer = "";

    public void keyPressed()
    {
        if (inputKey == "OK")
        {
            checkerProgram.attemptedPasscode = _dataBuffer;
            checkerProgram.validatePasscode();
        }
        else if (inputKey == "CLR")
        {
            resetInput();
            checkerProgram.logout();
        }
        // hard cap, only 8 digits long
        else if (_dataBuffer.Length < 8)
        {
            _dataBuffer += inputKey;
            displayProgram.text = _dataBuffer;
            displayProgram.printPassword();
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
