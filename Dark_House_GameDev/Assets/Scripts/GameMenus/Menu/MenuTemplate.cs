using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using GameMenus.MyButtons;
namespace GameMenus
{
    
    public abstract class MenuTemplateBase<T> : MenuTemplateBase
    {
        public List<MyButton> _buttonsList = new List<MyButton>(); 
        public MyButton _selectedButton;
        public MenuManager _menuManager;
        [SerializeField]private EventSystem _eventSystem;
        //public override event Action<BaseButton> OnSelectionChanged = button => {} ;
        
        
        private void CreateButton(Type type)
        {
            GameObject o = Instantiate(_menuManager.buttonPrefab, _menuManager.parent);
            Component component = o.AddComponent(type);
            var baseButton = component as MyButton;
            baseButton.Inject(this,_menuManager,null,null,_eventSystem);
            _buttonsList.Add(baseButton);
        }


        
        public override void DeSelect()
        {
            //enabled = false;

            foreach (var button in _buttonsList)
            {
                DestroyImmediate(button.gameObject);
            }
            
            _buttonsList.Clear();
        }

        public override void Select()
        {
            var types = GetType()
                .Assembly.GetTypes()
                .Where(type => type.GetCustomAttributes<ButtonOfMenuAttribute>()
                    .Any(attribute => attribute.GetMenu() == typeof(T)));
            
            foreach (var type in types)
                CreateButton(type);
            MyNullButton.Instance.Inject(this,_menuManager,_buttonsList.First().GetButton(),_buttonsList.Last().GetButton(),_eventSystem);
            
        }

        public override void Inject(MenuManager menuManager)
        {
            _menuManager = menuManager;
            print(_menuManager);
        }
    }
}