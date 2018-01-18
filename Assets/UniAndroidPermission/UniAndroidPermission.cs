using UnityEngine;
using System;
using System.Collections;

#if UNITY_ANDROID
public class UniAndroidPermission : MonoBehaviour {

    private static Action permitCallBack;
    private static Action notPermitCallBack;
    private static Action notPermitAndNverAskAgainCallbak;
    const string PackageClassName = "net.sanukin.PermissionManager";
    AndroidJavaClass permissionManager;

    void Awake(){
        DontDestroyOnLoad (gameObject);
    }

    public static bool IsPermitted(AndroidPermission permission){
#if UNITY_EDITOR
        Debug.LogWarning("UniAndroidPermission works only Androud Devices.");
        return true;
#elif UNITY_ANDROID
        AndroidJavaClass permissionManager = new AndroidJavaClass (PackageClassName);
        return permissionManager.CallStatic<bool> ("hasPermission", GetPermittionStr(permission));
#endif
        return true;
    }

    public static void RequestPermission(AndroidPermission permission, Action onPermit = null, Action notPermit = null, Action notPermitAndNeverAskAgain = null){
#if UNITY_EDITOR
        Debug.LogWarning("UniAndroidPermission works only Androud Devices.");
        return;
#elif UNITY_ANDROID
        AndroidJavaClass permissionManager = new AndroidJavaClass (PackageClassName);
        permissionManager.CallStatic("requestPermission", GetPermittionStr(permission));
        permitCallBack = onPermit;
        notPermitCallBack = notPermit;
        notPermitAndNverAskAgainCallbak = notPermitAndNeverAskAgain;
#endif
    }

    private static string GetPermittionStr(AndroidPermission permittion){
        return "android.permission." + permittion.ToString ();
    }

    private void OnAllow(){
        if (permitCallBack != null) {
            permitCallBack ();
        }
        ResetCallBacks ();
    }

    private void OnDeny(){
        if (notPermitCallBack != null) {
            notPermitCallBack ();
        }
        ResetCallBacks ();
    }

    private void OnDenyWithNeverAskAgainOption()
    {
        if (notPermitAndNverAskAgainCallbak != null)
        {
            notPermitAndNverAskAgainCallbak();
        }
        ResetCallBacks();
    }

    private void ResetCallBacks(){
        notPermitCallBack = null;
        permitCallBack = null;
        notPermitAndNverAskAgainCallbak = null;
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