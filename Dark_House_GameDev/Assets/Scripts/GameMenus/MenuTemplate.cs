using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GameMenus.Buttons;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace GameMenus
{
    public abstract class MenuTemplate<T> : IMenuTemplate
    {
        public List<BaseButton> _buttonsList = new List<BaseButton>(); 
        private ISelectableButton _selectedButton;
        public MenuManager _menuManager;
        public override event Action<ISelectableButton> OnSelectionChanged = button => {} ;
        public override void SelectButton(ISelectableButton newButtonSelected)
        {
            print("newButton");
            if (_selectedButton == newButtonSelected)
                return;
            _selectedButton?.OnLeavingClicking();
            _selectedButton = newButtonSelected;
            _selectedButton?.OnClicking();
            OnSelectionChanged.Invoke(_selectedButton);
        
        }
        
        private void CreateButton(Type type)
        {
            print("creating button type: " + type.FullName);

            GameObject o = Instantiate(_menuManager.buttonPrefab, _menuManager.parent);
            Component component = o.AddComponent(type);
            var baseButton = component as BaseButton;
            print(baseButton);
            _buttonsList.Add(baseButton); 
            
        }

        private void OnEnable()
        {
            print("OnEnable: " + name);
            print(_menuManager);
            if (_menuManager.GetMenuSelected() != this as IMenuTemplate)
            {
                _menuManager.SelectMenu(this);
                return;
            }
               
            
            
        }

        private void OnDisable()
        {
            print("OnDisable: " + name);
            if (_menuManager.GetMenuSelected() == this as IMenuTemplate)
            {
                _menuManager.SelectMenu(null);
                return;
            }

            
            
        }

        public override void DeSelect()
        {
            enabled = false;

            foreach (var button in _buttonsList)
            {
                Destroy(button.gameObject);
            }
            
            _buttonsList.Clear();
        }

        public override void Select()
        {
            enabled = true;
            var types = GetType()
                .Assembly.GetTypes()
                .Where(type =>
                    type.GetCustomAttributes<ButtonOfMenuAttribute>()
                        .Any(attribute => attribute.GetMenu() == typeof(T)));
            foreach (var type in types) CreateButton(type);
        }

        public override void Inject(MenuManager menuManager)
        {
            _menuManager = menuManager;
            print(_menuManager);
        }
    }
}