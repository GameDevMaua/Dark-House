using System;
using UnityEngine;

namespace GameMenus
{
    public abstract class IMenuTemplate : MonoBehaviour
    {
        public abstract event Action<ISelectableButton> OnSelectionChanged;
        public abstract void SelectButton(ISelectableButton newButtonSelected);
        public abstract void DeSelect();
        public abstract void Select();
        public abstract void Inject(MenuManager menuManager);
    }
}