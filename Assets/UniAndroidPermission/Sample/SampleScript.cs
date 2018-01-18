using UnityEngine;
using UnityEngine.UI;

public class SampleScript : MonoBehaviour {

    [SerializeField] Text text;

    public void RequestPermission(){
        if (UniAndroidPermission.IsPermitted (AndroidPermission.WRITE_EXTERNAL_STORAGE)) {
            text.text = "WRITE_EXTERNAL_STORAGE is already permitted!!";
            return;
        }

        UniAndroidPermission.RequestPermission(AndroidPermission.WRITE_EXTERNAL_STORAGE, OnAllow, OnDeny, OnDenyAndNeverAskAgain);
    }

    private void OnAllow()
    {
        text.text = "WRITE_EXTERNAL_STORAGE is permitted NOW!!";
    }

    private void OnDeny()
    {
        text.text = "WRITE_EXTERNAL_STORAGE is NOT permitted...";
    }

    private void OnDenyAndNeverAskAgain()
    {
        text.text = "WRITE_EXTERNAL_STORAGE is NOT permitted and checked never ask again option";
    }
}
