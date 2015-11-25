# UniAndroidPremission
Plugin for use runtime permission at unity.
It works only Android Devices
![AndroidSS](https://github.com/sanukin39/UniAndroidPermission/blob/master/images/RuntimePermission.png)

## Installation
Use unitypackage under Distribution

## Usage

1 Add uses-permission at AndroidManifest

```
<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" /> 
```

2 Add UniAndroidPermission.prefab at boot scene  ※ Don't rename object name!!


3 Call method before function which need permissions

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


## License
Copyright (c) 2015 wataru.sanuki

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
