package net.sanukin;

import android.content.Context;
import android.content.pm.PackageManager;
import android.os.Build;
import android.util.Log;

import com.unity3d.player.UnityPlayer;

public class PermissionManager {

    public static void requestPermission(String permissionStr){
        if(!hasPermission(permissionStr)) {
            UnityPlayer.currentActivity.requestPermissions(new String[]{permissionStr}, 0);
        }
    }

    public static boolean hasPermission(String permissionStr) {
        if(Build.VERSION.SDK_INT < 23) {
            return true;
        }
        Context context = UnityPlayer.currentActivity.getApplicationContext();
        return context.checkCallingOrSelfPermission(permissionStr) == PackageManager.PERMISSION_GRANTED;
    }
}
