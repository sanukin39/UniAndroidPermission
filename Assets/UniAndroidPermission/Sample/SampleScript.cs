using UnityEngine;
using UnityEngine.UI;

public class SampleScript : MonoBehaviour {

    [SerializeField] Text text;

    public void RequestPermission(){
        if (UniAndroidPermission.IsPermitted (AndroidPermission.WRITE_EXTERNAL_STORAGE)) {
            text.text = "WRITE_EXTERNAL_STORAGE is already permitted!!";
            return;
        }

        UniAndroidPermission.RequestPermission (AndroidPermission.WRITE_EXTERNAL_STORAGE,
        () =>
        {
            text.text = "WRITE_EXTERNAL_STORAGE is permitted NOW!!";
        },
        () =>
        {
            Debug.Log("Not permitted");
            text.text = "WRITE_EXTERNAL_STORAGE is NOT permitted...";
        },
        () =>
        {
            Debug.Log("NotPermitted2");
            text.text = "WRITE_EXTERNAL_STORAGE is NOT permitted and checked never ask";
        });
    }
}
