using System;
using GameMenus.MyButtons;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameMenus
{
    public abstract class MenuTemplateAbstractClass : MonoBehaviour
    {
        // public abstract event Action<BaseButton> OnSelectionChanged;
        // public abstract void SetButton(BaseButton newButtonSelected);
        
        
        public abstract MyButton SelectedButton { get; set; }

        public abstract void DeSelect();
        public abstract void Select();
         public abstract void Inject(MenuManager menuManager, EventSystem eventSystem);
    }
}