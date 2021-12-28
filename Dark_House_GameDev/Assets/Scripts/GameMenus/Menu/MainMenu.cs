using System;
using UnityEngine;

namespace GameMenus.Implementations
{
    
    public class MainMenu : MenuTemplateAbstractClass<MainMenu>
    {
        [ContextMenu("Select This menu")]
        public void test()
        {
            _menuManager.SelectMenu(this);
        }
        
    }
}