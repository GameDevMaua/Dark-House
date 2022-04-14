using UnityEngine;

public class ControlsImageUI : MonoBehaviour{
    [SerializeField] private GameObject _imageGameObj;

    public void ChangeActivationOfImageGameObj() {
        _imageGameObj.SetActive(!_imageGameObj.activeInHierarchy);
    }


    private void Update() {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)) && _imageGameObj.activeSelf) {
            ChangeActivationOfImageGameObj();
        }
    }
}
