using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game_Scripts.UI
{
    public class SoundHelperHandler : MonoBehaviour
    {
        private Button _nullButton;
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _nullButton = GameObject.Find("NullButton").GetComponent<Button>();
            var buttonNavigation = _button.navigation;
            buttonNavigation.selectOnDown = _nullButton;
            buttonNavigation.selectOnUp = _nullButton;
            buttonNavigation.selectOnLeft = _nullButton;
            buttonNavigation.selectOnRight = _nullButton;
            _button.navigation = buttonNavigation;
        }
    }
}