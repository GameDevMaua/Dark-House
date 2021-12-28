
using System;
using UnityEngine;

namespace GameMenus.Implementations
{
    public class PauseMenu : MenuTemplateBase<PauseMenu>
    {
        [ContextMenu("Select This menu")]
        public void test()
        {
            _menuManager.SelectMenu(this);
        }

      
    }
}