
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Keypad_Settings : UdonSharpBehaviour
{
    [Tooltip("A list of valid passcodes. Synced with the Door Objects and Granted Set Active Objects arrays")]
    public string[] passcodes = { "2580" };

    [Header("Object Control")]
    [Tooltip("GameObjects that you want enabled or disabled upon successful code entered. Synced with Passcode and Granted Set Active Objects arrays")]
    public GameObject[] doorObjects;
    [Tooltip("Controls which Door Objects to enable or disable upon successful code.")]
    public bool[] grantedSetActiveObjects;
    [Tooltip("If passcode is denied, sets all Door Objects to their default active state (defined as the opposite of those listed in Granted Set Active Objects)")]
    public bool changeActiveStatesOnFail;
    [Tooltip("After pressing CLR, sets all Door objects to their default active state (defined as the opposite of those listed in Granted Set Active Objects)")]
    public bool changeActiveStatesOnLogout;

    [Header("Callback Programs")]
    [Tooltip("A Udon program that will be run when user enters successful code. Sends the keypadGranted custom event, and sets the code(string) variable")]
    public UdonBehaviour programGranted;
    [Tooltip("A Udon program that will be run when user enters unsuccessful code. Sends the keypadDenied custom event, and sets the code(string) variable")]
    public UdonBehaviour programDenied;
    [Tooltip("A Udon program that will be run when user presses CLR button. Sends the keypadClosed custom event")]
    public UdonBehaviour programClosed;

    [Header("Display Control")]
    [Tooltip("The text that will be displayed on the keypad when user enters successful code")]
    public string grantedText = "GRANTED";
    [Tooltip("The text that will be displayed on the keypad when user enters unsuccessful code")]
    public string deniedText = "DENIED";
    [Tooltip("The default text on the display")]
    public string displayText = "PASSCODE";
}
