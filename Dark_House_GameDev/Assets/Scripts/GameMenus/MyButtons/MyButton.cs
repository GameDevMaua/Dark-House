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
        
        protected Button _button;
        private MenuTemplateAbstractClass _menuTemplateAbstractClass;
        private MenuManager _menuManager;
        private EventSystem _eventSystem;
        private Button _upButton;
        private Button _downButton;

        [SerializeField] private GameObject prefab;
        #endregion

        #region public Events

        //public UnityEvent 

        #endregion
        
        #region Initialization

        public void Build()
        {
            if (_button is null)
                return;
            
            _button.onClick.AddListener(OnInputConfirm);
            var navigation = _button.navigation;
            //print(navigation);
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnUp = _upButton!= null ? _upButton : (gameObject.PreviewsChild() != null ? gameObject.PreviewsChild().GetComponent<Button>(): MyNullButton.Instance._button);
            navigation.selectOnDown = _downButton != null ? _downButton : (gameObject.NextChild() != null ? gameObject.NextChild().GetComponent<Button>():MyNullButton.Instance._button);
            _button.navigation = navigation;

            //print(GetType().Name);
            var gameObj = Resources.Load<GameObject>(GetType().Name);
            //print(gameObj);
            if (gameObj != null)
            {
                Instantiate(gameObj, transform);
            }
        }
        private void Start()
        {
            Build();
        }

        public void Inject(MenuTemplateAbstractClass menuTemplateAbstractClass,MenuManager menuManager,Button upButton,Button downButton, EventSystem eventSystem)
        {
            _menuTemplateAbstractClass = menuTemplateAbstractClass;
            _menuManager = menuManager;
            _upButton = upButton;
            _downButton = downButton;
            _eventSystem = eventSystem;

            _button = GetComponent<Button>();
        }

        #endregion
        
        #region Callback and events
        
        protected virtual void OnInputConfirm()
        {
        }

        public void OnSelect(BaseEventData eventData)
        {
            GetComponentInChildren<AudioSource>()?.Play();

            //_menuTemplateBase.SelectedButton = this;
        }

        public void OnDeselect(BaseEventData eventData)
        {
            // print("--------");
            // print(gameObject.name);
            // print(eventData.selectedObject.name);
            // print("deselected");
            // if (_menuTemplateBase.SelectedButton!=MyNullButton.Instance)
            // {
            //     _menuTemplateBase.SelectedButton = MyNullButton.Instance;
            //     _eventSystem.SetSelectedGameObject(MyNullButton.Instance.gameObject);
            // }
        }

        #endregion

        public Button GetButton()
        {
            return _button;
        }
    }
}