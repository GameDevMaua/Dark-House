using GameMenus.Implementations;
using UnityEngine;

namespace GameMenus.MyButtons.Implementation
{
    [ButtonOfMenu(typeof(MainMenu))]
    public class ButtonTest2 : MyButton
    {
        protected override void OnInputConfirm()
        {
            print("DebugButton2");

        }
    }
}