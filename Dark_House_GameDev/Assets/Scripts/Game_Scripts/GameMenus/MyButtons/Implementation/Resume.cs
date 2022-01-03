using GameMenus.Implementations;
using UnityEngine;

namespace GameMenus.MyButtons.Implementation
{
    //[ButtonOfMenu(typeof(PauseMenu))]
    public class Resume : MyButton
    {
        protected override void OnInputConfirm()
        {
            print("DebugButton3");

        }
    }
}