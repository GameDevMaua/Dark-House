using GameMenus.Implementations;
using UnityEngine;

namespace GameMenus.MyButtons.Implementation
{
    [ButtonOfMenu(typeof(MainMenu))][ButtonOfMenu(typeof(PauseMenu))]
    public class ButtonTest4 : MyButton
    {
        protected override void OnInputConfirm()
        {
            print("DebugButton4");

        }
    }
}