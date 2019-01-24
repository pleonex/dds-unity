# dds-vr
Virtual Reality in Oculus Go and DDS from RTI Connector


## How to create a virtual reality application for Oculus Go

These steps show how to create a Virtual Reality application with Unity
integrated with DDS.

1. Download Unity from [Unity Hub](https://forum.unity.com/threads/unity-hub-v-1-3-2-is-now-available.594139/)
    * Make sure to install the Android build component
2. Download the [Android SDK](https://developer.android.com/studio/?hl=es-419#command-tools)
3. Create a new 3D project with Unity
    * If you are using a Version Control System you may want to do some additional steps from [here](https://docs.unity3d.com/Manual/ExternalVersionControlSystemSupport.html)
4. Request an [Oculus Signature File](https://dashboard.oculus.com/tools/osig-generator/) for signing your application in your test device.
    * Copy the file into `<project>/Assets/Plugins/Android/assets/`
5. Under `Edit -> Project Settings -> Player -> XR Settings` check `Virtual Reality Supported`
    * Make sure you are under the "Android" tab.
    * Add a new Virtual Reality SDK, for instance `Oculus`.
    * Set also the `Package Name` under `Other settings`
    * Change the `Minimum API Level` to Android 19
    * Set `Write permission` to `External (SDCard)` to be able to load XML files from the external memory.
6. Add the connector references
    * Run `cd connector && ./build.sh` or `connector/build.ps1` to compile Connector
    * Copy `connector/src/Connector/bin/Debug/net35/*.dll` into `Assets/Plugins`
    * Copy `connector/rticonnextdds-connector/lib/armv7aAndroid2.3gcc4.8/librtiddsconnector.so` into `Assets/Plugins/Android/libs/armeabi-v7a`
7. Create a cube, associate a C# script file and start coding.
    * Select the cube and in the inspector panel, click on `Add component -> New script`
8. Deploy the Connector XML configuration file into the SD card.
    * `adb push Configuration.xml /sdcard/`
9. Build and deploy to Android
    * Before install, uninstall the old version: `adb uninstall com.company.program`
    * To install: `adb install com.company.program`
