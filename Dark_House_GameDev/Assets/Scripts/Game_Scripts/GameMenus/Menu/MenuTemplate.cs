using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using GameMenus.MyButtons;
using UnityEngine.UI;

namespace GameMenus
{
    
    public abstract class MenuTemplateAbstractClass<T> : MenuTemplateAbstractClass
    {
        public List<MyButton> _buttonsList = new List<MyButton>(); 
        public MenuManager _menuManager;
        [SerializeField]private EventSystem _eventSystem;
        
        private MyButton selectedButton;

        public override MyButton SelectedButton
        {
            get => selectedButton;
            set => selectedButton = value;
        }
        
        private void CreateButton(Type type)
        {
            GameObject o = Instantiate(_menuManager.buttonPrefab, _menuManager.parent);
            o.name = type.Name;
            var text = o.GetComponent<Text>();
            if (text is null) text = o.GetComponentInChildren<Text>();
            if (!(text is null)) text.text = o.name;
            
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
            // print(_buttonsList.First().GetButton());
            // print(_buttonsList.Last().GetButton());


            var myNullButton = MyNullButton.Instance;
            myNullButton.Inject(this,_menuManager,_buttonsList.Last().GetButton(),_buttonsList.First().GetButton(),_eventSystem);
            myNullButton.Build();
        }

        public override void Inject(MenuManager menuManager, EventSystem eventSystem)
        {
            _menuManager = menuManager;
            
            _eventSystem = eventSystem;
        }

        
        private void Update()
        {
            //print("----");
            //print(_eventSystem.currentSelectedGameObject);
            //print(_eventSystem.currentSelectedGameObject==null);
            if(_eventSystem.currentSelectedGameObject == null)
            {
                //print("huasdhuashd");
                //print(MyNullButton.Instance);
                _eventSystem.SetSelectedGameObject(MyNullButton.Instance.gameObject);
            }
            //print(_eventSystem.currentSelectedGameObject);
        }
    }
}