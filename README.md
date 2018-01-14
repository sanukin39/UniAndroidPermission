# UniAndroidPremission
Plugin for use runtime permission at unity.
It works only Android Devices
![AndroidSS](https://github.com/sanukin39/UniAndroidPermission/blob/master/images/RuntimePermission.png)

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

3 Add UniAndroidPermission.prefab at boot scene  ※ Don't rename object name!!


4 Call method before function which need permissions

Check if permission permitted.

```cs
UniAndroidPermission.IsPermitted (AndroidPermission.WRITE_EXTERNAL_STORAGE)
```

Request Permission by runtime permission

```cs
UniAndroidPermission.RequestPremission (AndroidPermission.WRITE_EXTERNAL_STORAGE, () => {
    // add permit action
}, () => {
    // add not permit action
});
```

## Author
[sanukin39](https://github.com/sanukin39)

## License
[The MIT License](https://github.com/sanukin39/UniAndroidPermission/blob/master/LICENSE)
