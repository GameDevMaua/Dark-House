using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameMenus.MyButtons
{
    [RequireComponent(typeof(Button))]
    public abstract class MyButton : MonoBehaviour , ISelectHandler , IDeselectHandler
    {
        #region Depencies
        
        private Button _button;
        private MenuTemplateBase _menuTemplateBase;
        private MenuManager _menuManager;
        private EventSystem _eventSystem;
        private Button _upButton;
        private Button _downButton;

        #endregion

        #region public Events

        //public UnityEvent 

        #endregion
        
        #region Initialization

        private void Start()
        {
            _button = GetComponent<Button>();

            if (_button is null)
                return;
            
            _button.onClick.AddListener(OnInputConfirm);
            var navigation = _button.navigation;
            print(navigation);
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnUp = _upButton ? _upButton : (gameObject.NextChild() != null ? gameObject.NextChild().GetComponent<Button>(): MyNullButton.Instance._button);
            navigation.selectOnDown = _upButton ? _upButton : (gameObject.PreviewsChild() != null ?gameObject.PreviewsChild().GetComponent<Button>():MyNullButton.Instance._button);
            _button.navigation = navigation;
        }

        public void Inject(MenuTemplateBase menuTemplateBase,MenuManager menuManager,Button upButton,Button downButton, EventSystem eventSystem)
        {
            _menuTemplateBase = menuTemplateBase;
            _menuManager = menuManager;
            _upButton = upButton;
            _downButton = downButton;
            _eventSystem = eventSystem;
        }

        #endregion
        
        #region Callback and events
        
        protected virtual void OnInputConfirm()
        {
            print("confirm");
        }

        public void OnSelect(BaseEventData eventData)
        {
            print("selected");
        }

        public void OnDeselect(BaseEventData eventData)
        {
         
            print("deselected");
        }

        #endregion

        public Button GetButton()
        {
            return _button;
        }
    }
}