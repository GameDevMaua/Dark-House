// using System;
// using DefaultNamespace;
// using GameMenus.Implementations;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;
//
//
// namespace GameMenus.Buttons
// {
//     
//     public abstract class BaseButton : MonoBehaviour
//     {
//         protected MenuTemplateBase _currentMenu;
//         protected MenuManager _menuManager;
//         protected EventSystem _eventSystem;
//         
//         public BaseButton _upButton;
//         public BaseButton _downButton;
//
//         public Button button;
//         private void Start()
//         {
//             gameObject.name = GetType().Name;
//             button = GetComponentInChildren<Button>();
//             if (!button) return;
//
//             var text = GetComponentInChildren<Text>();
//             var objectName = GetType().FullName!;
//             text.text = objectName!;
//
//
//             _downButton = gameObject.NextChild() != null ? gameObject.NextChild().GetComponentInChildren<BaseButton>() : null;
//             _upButton = gameObject.PreviewsChild() != null ? gameObject.PreviewsChild().GetComponentInChildren<BaseButton>() : null;
//
//             var buttonNavigation = button.navigation;
//             buttonNavigation.selectOnUp = _upButton != null ? _upButton.button : null;
//             buttonNavigation.selectOnDown = _downButton != null ? _downButton.button : null;
//             button.navigation = buttonNavigation;
//                 
//             button.onClick.AddListener(OnConfirm);
//         }
//
//         private void OnClicking()
//         {
//             _currentMenu.SetButton(this);
//         }
//
//
//         private void OnConfirm()
//         {
//             print("confirmed button:");
//         }
//
//         public virtual void Inject(MenuTemplateBase menuTemplateBase,MenuManager menuManager)
//         {
//             _currentMenu = menuTemplateBase;
//             _menuManager = menuManager;
//         }
//
//       
//
//         public void OnLeaving()
//         {
//             print("leaving");
//             _menuManager.OnInputUp -= InputUp;
//             _menuManager.OnInputDown -= InputDown;
//             _menuManager.OnInputConfirm -= OnConfirm;
//         }
//
//         public void OnEntering()
//         {
//             print("entering");
//             _menuManager.OnInputUp += InputUp;
//             _menuManager.OnInputDown += InputDown;
//             _menuManager.OnInputConfirm += OnConfirm;
//         }
//
//         private void InputDown()
//         {
//             _currentMenu.SetButton(_downButton ? _downButton : NullButton.Instance);
//         }
//
//         private void InputUp()
//         {
//             _currentMenu.SetButton(_upButton ? _upButton : NullButton.Instance);
//         }
//         
//     }
// }