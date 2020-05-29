
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Keypad_Settings : UdonSharpBehaviour
{
    public GameObject[] doorObjects;
    public UdonBehaviour programGranted;
    public UdonBehaviour programDenied;
    public UdonBehaviour programClosed;
    public string[] passcodes = { "2580" };
    public bool[] grantedSetActiveObjects;
    public bool changeActiveStatesOnFail;
    public bool changeActiveStatesOnLogout;
}
