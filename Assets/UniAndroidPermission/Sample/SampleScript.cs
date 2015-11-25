using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SampleScript : MonoBehaviour {

    [SerializeField] Text text;

    public void RequestPermission(){
        if (UniAndroidPermission.IsPermitted (AndroidPermission.WRITE_EXTERNAL_STORAGE)) {
            text.text = "WRITE_EXTERNAL_STORAGE is already permitted!!";
            return;
        }

        UniAndroidPermission.RequestPremission (AndroidPermission.WRITE_EXTERNAL_STORAGE, () => {
            text.text = "WRITE_EXTERNAL_STORAGE is permitted NOW!!";
        }, () => {
            text.text = "WRITE_EXTERNAL_STORAGE id NOT permitted...";
        });
    }
}
