using UnityEngine;
using System;
using System.Collections;

#if UNITY_ANDROID
public class UniAndroidPermission : MonoBehaviour {

    private static Action permitCallBack;
    private static Action notPermitCallBack;
    AndroidJavaClass permissionManager;

    void Awake(){
        DontDestroyOnLoad (gameObject);
    }

    public static bool IsPermitted(AndroidPermission permission){
#if UNITY_EDITOR
        Debug.LogWarning("UniAndroidPermission works only Androud Devices.");
        return true;
#endif
        AndroidJavaClass permissionManager = new AndroidJavaClass ("jp.ne.donuts.uniandroidpermission.PermissionManager");
        return permissionManager.CallStatic<bool> ("hasPermission", GetPermittionStr(permission));
    }

    public static void RequestPremission(AndroidPermission permission, Action onPermit = null, Action notPermit = null){
#if UNITY_EDITOR
        Debug.LogWarning("UniAndroidPermission works only Androud Devices.");
        return;
#endif
        AndroidJavaClass permissionManager = new AndroidJavaClass ("jp.ne.donuts.uniandroidpermission.PermissionManager");
        permissionManager.CallStatic("requestPermission", GetPermittionStr(permission));
        permitCallBack = onPermit;
        notPermitCallBack = notPermit;
    }

    private static string GetPermittionStr(AndroidPermission permittion){
        return "android.permission." + permittion.ToString ();
    }

    private void OnPermit(){
        if (permitCallBack != null) {
            permitCallBack ();
        }
        ResetCallBacks ();
    }

    private void NotPermit(){
        if (notPermitCallBack != null) {
            notPermitCallBack ();
        }
        ResetCallBacks ();
    }

    private void ResetCallBacks(){
        notPermitCallBack = null;
        permitCallBack = null;
    }
}

// Protection level: dangerous permissions 2015/11/25
// http://developer.android.com/intl/ja/reference/android/Manifest.permission.html
public enum AndroidPermission{
    ACCESS_COARSE_LOCATION,
    ACCESS_FINE_LOCATION,
    ADD_VOICEMAIL,
    BODY_SENSORS,
    CALL_PHONE,
    CAMERA,
    GET_ACCOUNTS,
    PROCESS_OUTGOING_CALLS,
    READ_CALENDAR,
    READ_CALL_LOG,
    READ_CONTACTS,
    READ_EXTERNAL_STORAGE,
    READ_PHONE_STATE,
    READ_SMS,
    RECEIVE_MMS,
    RECEIVE_SMS,
    RECEIVE_WAP_PUSH,
    RECORD_AUDIO,
    SEND_SMS,
    USE_SIP,
    WRITE_CALENDAR,
    WRITE_CALL_LOG,
    WRITE_CONTACTS,
    WRITE_EXTERNAL_STORAGE
}
#endif