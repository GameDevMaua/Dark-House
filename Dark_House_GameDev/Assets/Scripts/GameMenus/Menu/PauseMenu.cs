
using System;
using UnityEngine;

namespace GameMenus.Implementations
{
    public class PauseMenu : MenuTemplateAbstractClass<PauseMenu>
    {
        [ContextMenu("Select This menu")]
        public void test()
        {
            _menuManager.SelectMenu(this);
        }

      
    }
}