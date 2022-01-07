using GameMenus.Implementations;
using UnityEngine;

namespace GameMenus.MyButtons.Implementation
{
    [ButtonOfMenu(typeof(MainMenu))][ButtonOfMenu(typeof(PauseMenu))]
    public class Quit : MyButton
    {
        protected override void OnInputConfirm()
        {
            Application.Quit();

        }
    }
}