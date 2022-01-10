using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameMenus
{
    public abstract class ButtonTemplate : MonoBehaviour
    {
        private Button _button;
        protected  Animator sceneDarker;
        private void Start()
        {
            sceneDarker = GameObject.Find("BlackCover").GetComponentInChildren<Animator>();
            _button = GetComponentInChildren<Button>();
            _button.onClick.AddListener(OnButtonClicked);
        }

        protected abstract void OnButtonClicked();
    }
}