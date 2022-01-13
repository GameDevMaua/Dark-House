using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace Game_Scripts.UI
{
    public class NullButtonHandler : MonoBehaviour 
    {
        private GameObject _imageBackground;
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _imageBackground = GameObject.Find("ImageBackground");
            var nav = _button.navigation;
            nav.selectOnUp = _imageBackground.GetLastChildren().GetComponentInChildren<Button>();
            nav.selectOnDown = _imageBackground.GetFirstChildren().GetComponentInChildren<Button>();
            _button.navigation = nav;
        }
    }
}