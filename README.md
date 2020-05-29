
# VRChat Udon Keypad
![](https://github.com/cherryleafroad/VRChat_Keypad/blob/master/README_assets/keypad2.png)
An advanced Udon keypad that can be used to create special passcodes on your world. Implemented using UdonSharp
## Features

 - Support for multiple passcodes
 - Can enable or disable gameobjects per passcode (advanced; see the `doorObjects` and`grantedSetActive` settings)
 - Can run an Udon program upon successful, denied, or logout event (pressing CLS button). Also passes the passcode used to the Udon program so that you can know how to react in your script

## Requirements
Udon Sharp - Make sure you install it before importing this project
[https://github.com/Merlin-san/UdonSharp](https://github.com/Merlin-san/UdonSharp)

## Documentation

 - **Passcodes option:** Add as many passcodes as you want! There's no limit
 
 - **DoorObjects:** This allows you to enable or disable an object automatically when a passcode is granted, denied, or on logoff. Arrays are synced, meaning, the first passcode in the passcodes array corresponds to the first object in the doorobjects array.
 
 - **Programs**

Enabling or disabling objects upon accepted code not advanced enough? You can enter your very own Udon program as a callback, and it also sends the used code, and you can program WHATEVER you want for a particular code!
 
| Program        | CustomEvent   | ProgramVariableName(type) | Runs on                    |
|----------------|---------------|---------------------------|------------------------------|
| programGranted | keypadGranted | code(string)              | successful code   |
| programDenied  | keypadDenied  | code(string)              | denied code       |
| programClosed  | keypadClosed  |                           | pressing clear/CLS |


- **Granted set active objects:** An array of booleans which says whether to enable or disable a particular object relating to the doorobjects array upon successful activation of a code. It is synced to the array again. E.g. array element 2 corresponds to array element 2 of doorobjects.

- **Change active states on fail:** If a passcode is denied, it will change the active states of all doorObjects to the OPPOSITE of the granted set active objects booleans. (Basically, it reverses the active state). Note: This will change the active state of all objects in the array (basically resetting them all to default).

- **Change active states on logout:** When you press the CLS button, it will change the active states of all doorObjects to the OPPOSITE of the granted set active objects booleans. (Basically, it reverses the active state). Note: This will change the active state of all objects in the array (basically resetting them all to default)

### Credits
Foorack for the original version (originally implemented using UdonGraph)

[https://blog.foorack.com/keypad-prefab-in-udon-for-vrchat/](https://blog.foorack.com/keypad-prefab-in-udon-for-vrchat/)
