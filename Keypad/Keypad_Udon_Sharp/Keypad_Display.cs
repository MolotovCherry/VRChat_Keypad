
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using VRC.Udon.Wrapper.Modules;

public class Keypad_Display : UdonSharpBehaviour
{
    [HideInInspector]
    public string text;
    public string defaultText = "PASSCODE";
    private int length;
    private Text output;

    public void Start()
    {
        output = GetComponent<Text>();

        resetDisplay();
    }

    public void resetDisplay()
    {
        text = defaultText;
        printText();
    }

    public void printText()
    {
        output.text = text;
    }

    public void printPassword()
    {
        // text variable is already set to password
        // before calling this method
        length = text.Length;

        // we now have the length of the password
        // but we need to empty out the string
        // so that we don't show the password AND * chars
        text = "";

        for (int i = 0; i < length; i++)
        {
            text += "*";
        }

        printText();
    }
}
