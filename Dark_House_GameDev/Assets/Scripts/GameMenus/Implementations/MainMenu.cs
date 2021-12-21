using System;
using System.Collections.Generic;
using GameMenus;
using UnityEngine;

public class TestAttribute : System.Attribute
{
    public Type menu;
    public TestAttribute(Type menuType)
    {
        menu = menuType;
    }
        
}


namespace GameMenus.Implementations
{
    
    public class MainMenu : MenuTemplate
    {
        
    }
}