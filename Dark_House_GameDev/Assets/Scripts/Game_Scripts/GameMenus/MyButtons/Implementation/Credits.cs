using GameMenus.Implementations;
using UnityEngine;

namespace GameMenus.MyButtons.Implementation
{
    //[ButtonOfMenu(typeof(MainMenu))]
    public class Credits : MyButton
    {
        protected override void OnInputConfirm()
        {
            print("DebugButton3");

        }
    }
}