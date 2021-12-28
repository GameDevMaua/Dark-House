using System;
using UnityEngine;

namespace GameMenus
{
    public abstract class MenuTemplateBase : MonoBehaviour
    {
        // public abstract event Action<BaseButton> OnSelectionChanged;
        // public abstract void SetButton(BaseButton newButtonSelected);
        public abstract void DeSelect();
        public abstract void Select();
         public abstract void Inject(MenuManager menuManager);
    }
}