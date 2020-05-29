
using UdonSharp;
using UnityEngine;
using VRC.Udon;

public class Keypad_SolutionChecker : UdonSharpBehaviour
{
    public GameObject settingsObj;
    public UdonBehaviour settings;
    public UdonBehaviour inputProgram;
    public UdonBehaviour displayProgram;
    public string attemptedPasscode;

    public void validatePasscode()
    {
        GameObject[] doorObjects = (GameObject[]) settings.GetProgramVariable("doorObjects");
        string[] passcodes = (string[]) settings.GetProgramVariable("passcodes");
        UdonBehaviour programGranted = (UdonBehaviour) settings.GetProgramVariable("programGranted");
        UdonBehaviour programDenied = (UdonBehaviour) settings.GetProgramVariable("programDenied");
        bool[] setActiveBools = (bool[]) settings.GetProgramVariable("grantedSetActiveObjects");
        bool changeActiveOnFail = (bool) settings.GetProgramVariable("changeActiveStatesOnFail");

        inputProgram.SendCustomEvent("resetInput");

        int plength = passcodes.Length;

        for (int i = 0; i < plength; i++)
        {
            if (attemptedPasscode == passcodes[i])
            {
                displayProgram.SetProgramVariable("text", "GRANTED");
                displayProgram.SendCustomEvent("printText");

                int dlength = doorObjects.Length - 1;
                // make sure an object exists for this current interation, if not just ignore it
                if (dlength >= i)
                {
                    // not the settings obj, and not null! good!
                    if ((doorObjects[i] != settingsObj) && (doorObjects[i] != null))
                    {
                        // make sure active bool exists for this object
                        if ((setActiveBools.Length - 1) >= i)
                        {
                            doorObjects[i].SetActive(setActiveBools[i]);
                        }
                        else
                        {
                            // default behavior
                            doorObjects[i].SetActive(false);
                        }
                    }
                }

                if (programGranted != null)
                {
                    // in the script, you can know which code was used to differentiate between multiple codes
                    programGranted.SetProgramVariable("code", attemptedPasscode);
                    programGranted.SendCustomEvent("keypadGranted");
                }

                break;
            }
            else
            {
                // last iteration, no matches, so reset display
                if (i == (plength-1)) {
                    displayProgram.SendCustomEvent("resetDisplay");
                }

                // whether to make changes to active state of object if passcode doesn't go through
                // This can have the effect of disabling/enabling all non-successful active objects when we press OK
                if (changeActiveOnFail)
                {
                    int dlength = doorObjects.Length - 1;
                    // make sure an object exists for this current interation, if not just ignore it
                    if (dlength >= i)
                    {
                        // not the settings obj, and not null! good!
                        if ((doorObjects[i] != settingsObj) && (doorObjects[i] != null))
                        {
                            // make sure active bool exists for this object
                            if ((setActiveBools.Length - 1) >= i)
                            {
                                doorObjects[i].SetActive(!setActiveBools[i]);
                            }
                            else
                            {
                                // default behavior
                                doorObjects[i].SetActive(true);
                            }
                        }
                    }
                }

                if (programDenied != null)
                {
                    // in the script, you can know which code was used to differentiate between multiple codes
                    programDenied.SetProgramVariable("code", attemptedPasscode);
                    programDenied.SendCustomEvent("keypadDenied");
                }
            }
        }
    }

    public void logout()
    {
        GameObject[] doorObjects = (GameObject[]) settings.GetProgramVariable("doorObject");
        UdonBehaviour programClosed = (UdonBehaviour) settings.GetProgramVariable("programClosed");
        bool changeActiveStatesOnLogout = (bool) settings.GetProgramVariable("changeActiveStatesOnLogout");
        bool[] setActiveBools = (bool[])settings.GetProgramVariable("grantedSetActiveObjects");

        displayProgram.SendCustomEvent("resetDisplay");

        // disable / enable all objects on logout
        // actually, all it does is flip them opposite of their granted state
        if (changeActiveStatesOnLogout)
        {
            for (int i=0; i<doorObjects.Length; i++)
            {
                // not the settings obj, and not null! good!
                if ((doorObjects[i] != settingsObj) && (doorObjects[i] != null))
                {
                    // make sure active bool exists for this object
                    if ((setActiveBools.Length - 1) >= i)
                    {
                        doorObjects[i].SetActive(!setActiveBools[i]);
                    }
                    else
                    {
                        // default behavior
                        doorObjects[i].SetActive(true);
                    }
                }
            }
        }


        if (programClosed != null)
        {
            programClosed.SendCustomEvent("keypadClosed");
        }
    }
}
