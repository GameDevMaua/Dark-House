using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace GameMenus
{
    
    public abstract class MenuTemplate : MonoBehaviour
    {
        private ISelectableButton _selectedButton;
        [SerializeField] private GameObject buttonPrefab;
        [SerializeField] private Transform parent;


        public event Action<ISelectableButton> OnSelectionChanged = button => {} ;
        public void SelectButton(ISelectableButton newButtonSelected)
        {
            print("newButton");
            if (_selectedButton == newButtonSelected)
                return;
            _selectedButton?.OnLeavingClicking();
            _selectedButton = newButtonSelected;
            _selectedButton?.OnClicking();
            OnSelectionChanged.Invoke(_selectedButton);
        
        }
        // Start is called before the first frame update
        void Start()
        {
            print("aaa");
            var a = Assembly.GetAssembly(typeof(MenuTemplate));
        
        
            foreach (var type in a.GetTypes().Where(type => !(type.GetCustomAttribute<TestAttribute>() is null) )  )
            {
                print(type.Name);
                var attribute = type.GetCustomAttribute<TestAttribute>();

                if (attribute.menu == this.GetType())
                {
                    CreateButton(type);
                }
            }
        }

        private void CreateButton(Type type)
        {
            GameObject a =Instantiate(buttonPrefab, parent);
            a.AddComponent(type);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void DeSelect()
        {
            throw new NotImplementedException();
        }

        public void Select()
        {
            throw new NotImplementedException();
        }
    }

    public interface ISelectableButton
    {
        void OnLeavingClicking();
        void OnClicking();
    }
}