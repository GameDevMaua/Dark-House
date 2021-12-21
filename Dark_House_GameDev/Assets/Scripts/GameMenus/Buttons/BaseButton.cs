using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace GameMenus.Buttons
{
    public abstract class BaseButton : MonoBehaviour, ISelectableButton
    {
        private MenuTemplate _currentMenu;
        private ISelectableButton _downButton;
        private ISelectableButton _upButton;

        private void Start()
        {
            var button = GetComponentInChildren<Button>();
            var text = GetComponentInChildren<Text>();

            button.onClick.AddListener(OnClicking);
            var objectName = GetType().FullName!;
            text.text = objectName!;
            gameObject.name = objectName!;

            _downButton = gameObject.NextChild()?.GetComponentInChildren<BaseButton>();
            _upButton = gameObject.PreviewsChild()?.GetComponentInChildren<BaseButton>();
            print(_downButton);
            print(_upButton);

        }
    
       
        private void OnConfirm()
        {
            
        }

        public void OnLeavingClicking()
        {
            MenuManager.Instance.OnInputUp -= InputUp;
            MenuManager.Instance.OnInputDown -= InputDown;
        }

        public void OnClicking()
        {
            MenuManager.Instance.OnInputUp += InputUp;
            MenuManager.Instance.OnInputDown += InputDown;
            _currentMenu.SelectButton(this);
        }

        private void InputDown()
        {
            _currentMenu.SelectButton(_downButton);
        }

        private void InputUp()
        {
            _currentMenu.SelectButton(_upButton);
        }
    }
}