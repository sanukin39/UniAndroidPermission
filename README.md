# UniAndroidPremission
Plugin for use runtime permission at unity.
It works only Android Devices
![runtimepermission](https://user-images.githubusercontent.com/6077255/35118396-f709f9c2-fcd4-11e7-9862-4d31c87f22a5.png)

## Requirement
Unity5 or higher

## Installation
Use unitypackage at the [release page](https://github.com/sanukin39/UniAndroidPermission/releases)

## Usage

1 Add uses-permission to AndroidManifest

```
<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" /> 
```

2 Add Custom Activity and SkipPermissionsDialog to Android Manifest

```
<activity android:name=“net.sanukin.OverrideUnityActivity"
         android:label="@string/app_name"
         android:configChanges="fontScale|keyboard|keyboardHidden|locale|mnc|mcc|navigation|orientation|screenLayout|screenSize|smallestScreenSize|uiMode|touchscreen">
    <intent-filter>
        <action android:name="android.intent.action.MAIN" />
        <category android:name="android.intent.category.LAUNCHER" />
    </intent-filter>
</activity>
<meta-data android:name="unityplayer.SkipPermissionsDialog" android:value="true" />
```

3 Add UniAndroidPermission.prefab at boot scene   <b>※ Don't rename object name!!</b>


4 Call method before function which need permissions

Check if permission permitted.

```cs
UniAndroidPermission.IsPermitted (AndroidPermission.WRITE_EXTERNAL_STORAGE)
```

Request Permission

```cs
public void RequestPermission()
{
    UniAndroidPermission.RequestPermission(AndroidPermission.WRITE_EXTERNAL_STORAGE, OnAllow, OnDeny, OnDenyAndNeverAskAgain);
}

private void OnAllow()
{
    // execute action that uses permitted function.
}

private void OnDeny()
{
    // back screen / show warnking window
}

private void OnDenyAndNeverAskAgain()
{
    // show warning window and open app permission setting page
}
```

## Author
[sanukin39](https://github.com/sanukin39)

## License
[The MIT License](https://github.com/sanukin39/UniAndroidPermission/blob/master/LICENSE)
