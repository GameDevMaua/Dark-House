using System;
using GameMenus.Implementations;
using UnityEngine;

namespace GameMenus.MyButtons.Implementation
{
    [ButtonOfMenu(typeof(MainMenu))]
    public class ButtonTest1 : MyButton
    {
        protected override void OnInputConfirm()
        {
            print("DebugButton1");
        }
    }
}