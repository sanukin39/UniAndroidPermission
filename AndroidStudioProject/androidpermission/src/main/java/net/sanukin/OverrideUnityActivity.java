package net.sanukin;

import android.content.pm.PackageManager;
import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;

/**
 * Created by sanuki.wataru on 2016/05/18.
 */
public class OverrideUnityActivity extends UnityPlayerActivity {

    @Override
    public void onRequestPermissionsResult(int requestCode, String permissions[], int[] grantResults) {
        switch (requestCode) {
            case 0: {
                if (grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                    UnityPlayer.UnitySendMessage("UniAndroidPermission", "OnPermit", "");
                } else {
                    UnityPlayer.UnitySendMessage("UniAndroidPermission", "NotPermit", "");
                }
                break;
            }
        }
    }
}
