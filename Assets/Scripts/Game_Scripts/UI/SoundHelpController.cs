using System;
using Game_Scripts.GameMenus;
using UnityEngine;
using UnityEngine.UI;

namespace GameMenus.MyButtons
{
    [RequireComponent(typeof(Toggle))]
    public class SoundHelpController: MonoBehaviour
    {
        public static bool isEnabled = true;
        private Toggle _toggle;

        private void Start()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.isOn = isEnabled;
            _toggle.onValueChanged.AddListener(OnToggleChanged);
            OnToggleChanged(isEnabled);
        }

        private void OnToggleChanged(bool value)
        {
            isEnabled = value;
            foreach (var buttonSoundPlayer in FindObjectsOfType<ButtonSoundPlayer>())
            {
                buttonSoundPlayer.enabled = isEnabled;
            }
        }
    }
}