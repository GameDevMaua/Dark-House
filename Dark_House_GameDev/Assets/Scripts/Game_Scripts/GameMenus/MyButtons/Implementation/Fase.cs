using System;
using GameMenus.Implementations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameMenus.MyButtons.Implementation
{
    [ButtonOfMenu(typeof(MainMenu))]
    public class Fase : MyButton
    {
        protected override void OnInputConfirm()
        {
            SceneManager.LoadScene("MapaTeste2.0_Felipe");
        }
    }
}