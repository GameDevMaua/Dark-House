using System;
using System.Linq;
using System.Reflection;
using Core;
using UnityEngine;

namespace GameMenus
{
    public class MenuManager : MonoBehaviourSingletonPersistent<MenuManager>
    {
        public GameObject buttonPrefab;
        public Transform parent;
        
        public event Action OnInputUp = () => print("input up");
        public event Action OnInputDown= () => print("input down");
        public event Action OnInputConfirm = () => print("enter input");
        private void Update()
        {
           
            if (Input.GetKeyUp(KeyCode.UpArrow))
                OnInputUp?.Invoke();
            if (Input.GetKeyUp(KeyCode.DownArrow))
                OnInputDown?.Invoke();
            if (Input.GetKeyDown(KeyCode.Space))
                OnInputConfirm?.Invoke();
        }

        [SerializeField]private IMenuTemplate _menuTemplateSelected;
        public event Action<IMenuTemplate> OnMenuSelectionChanged = menu => { };

        public IMenuTemplate GetMenuSelected()
        {
            return _menuTemplateSelected;
        }
        public void SelectMenu(IMenuTemplate newMenuTemplateSelected)
        {
            if(_menuTemplateSelected == newMenuTemplateSelected)
                return;
            _menuTemplateSelected?.DeSelect();
            _menuTemplateSelected = newMenuTemplateSelected;
            _menuTemplateSelected?.Select();
            OnMenuSelectionChanged.Invoke(_menuTemplateSelected);
        }
       
        [ContextMenu("rebuild menu")]
        private void RebuildMenus()
        {
            gameObject.name = GetType().FullName!;

            

            Debug.LogWarning("on validating");

            // var b = a.GetTypes();//.Where(type => type.IsAssignableFrom(typeof(Menu)));
            // foreach (var type in b)
            // {
            //    print(type.IsSubclassOf(typeof(MenuTemplate)));
            // }
            foreach (var menuType in GetType().Assembly.GetTypes().Where(type => typeof(IMenuTemplate).IsAssignableFrom(type) && !type.IsAbstract) )
            {
                print(menuType.FullName);
                if (!GameObject.Find(menuType.FullName))
                    CreateNewMenu(menuType);
            }
        }

        private void CreateNewMenu(Type menuType)
        {
            //print(menuType.FullName);
            print(this);
            var newGameObject = new GameObject(menuType.FullName);
            var component = newGameObject.AddComponent(menuType) as IMenuTemplate;
            print(this);
            component.Inject(this);
        }
    }
}