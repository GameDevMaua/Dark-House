using System;
using System.Linq;
using System.Reflection;
using Core;
using UnityEngine;

namespace GameMenus
{
    public class MenuManager : MonoBehaviourSingletonPersistent<MenuManager>
    {
        public event Action OnInputUp;
        public event Action OnInputDown;

        private void Update()
        {
            
            if (Input.GetKeyUp(KeyCode.UpArrow))
                OnInputUp?.Invoke();
            if (Input.GetKeyUp(KeyCode.DownArrow))
                OnInputDown?.Invoke();
        }

        private MenuTemplate _menuTemplateSelected;
        public event Action<MenuTemplate> OnMenuSelectionChanged = menu => { };

        public void SelectMenu(MenuTemplate newMenuTemplateSelected)
        {
            if(_menuTemplateSelected == newMenuTemplateSelected)
                return;
            _menuTemplateSelected?.DeSelect();
            _menuTemplateSelected = newMenuTemplateSelected;
            _menuTemplateSelected?.Select();
            OnMenuSelectionChanged.Invoke(_menuTemplateSelected);
        }
        private void Start()
        {
        }

        [ContextMenu("rebuild menu")]
        private void RebuildMenus()
        {
            gameObject.name = GetType().FullName!;

            
            var a = Assembly.GetAssembly(typeof(MenuTemplate));

            Debug.LogWarning("on validating");

            // var b = a.GetTypes();//.Where(type => type.IsAssignableFrom(typeof(Menu)));
            // foreach (var type in b)
            // {
            //    print(type.IsSubclassOf(typeof(MenuTemplate)));
            // }
            foreach (var menuType in a.GetTypes().Where(type => type.IsSubclassOf(typeof(MenuTemplate)) && !type.IsAbstract))
            {
                print(menuType.FullName);
                if (!GameObject.Find(menuType.FullName))
                    CreateNewMenu(menuType);
            }
        }

        private void CreateNewMenu(Type menuType)
        {
            //print(menuType.FullName);
            var newGameObject = new GameObject(menuType.FullName);
            newGameObject.AddComponent(menuType);
        }
    }
}