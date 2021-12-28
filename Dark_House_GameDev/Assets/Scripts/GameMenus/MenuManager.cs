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
        
        
        [SerializeField]private MenuTemplateAbstractClass menuTemplateAbstractClassSelected;
        public MenuTemplateAbstractClass _firstMenuSelected;
        public event Action<MenuTemplateAbstractClass> OnMenuSelectionChanged = menu => { };

        public event Action OnInputUp;// = () => print("input up");
        public event Action OnInputDown;//= () => print("input down");
        public event Action OnInputConfirm;// = () => print("enter input");
        private void Update()
        {
           
            if (Input.GetKeyUp(KeyCode.UpArrow))
                OnInputUp?.Invoke();
            if (Input.GetKeyUp(KeyCode.DownArrow))
                OnInputDown?.Invoke();
            if (Input.GetKeyDown(KeyCode.Space))
                OnInputConfirm?.Invoke();
        }

        public void Start()
        {
            SelectMenu(_firstMenuSelected);
        }

        public MenuTemplateAbstractClass GetMenuSelected()
        {
            return menuTemplateAbstractClassSelected;
        }
        public void SelectMenu(MenuTemplateAbstractClass newMenuTemplateAbstractClassSelected)
        {
            if(menuTemplateAbstractClassSelected == newMenuTemplateAbstractClassSelected)
                return;
            menuTemplateAbstractClassSelected?.DeSelect();
            menuTemplateAbstractClassSelected?.gameObject.SetActive(false);
            menuTemplateAbstractClassSelected = newMenuTemplateAbstractClassSelected;
            menuTemplateAbstractClassSelected?.Select();
            menuTemplateAbstractClassSelected?.gameObject.SetActive(true);
            OnMenuSelectionChanged.Invoke(menuTemplateAbstractClassSelected);
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
            foreach (var menuType in GetType().Assembly.GetTypes().Where(type => typeof(MenuTemplateAbstractClass).IsAssignableFrom(type) && !type.IsAbstract) )
            {
                print(menuType.FullName);
                if (!GameObject.Find(menuType.FullName))
                    CreateNewMenu(menuType);
            }
        }

        private void CreateNewMenu(Type menuType)
        {
            //print(menuType.FullName);
            //print(this);
            var newGameObject = new GameObject(menuType.FullName);
            var component = newGameObject.AddComponent(menuType) as MenuTemplateAbstractClass;
            //print(this);
            component.Inject(this);
        }
    }
}