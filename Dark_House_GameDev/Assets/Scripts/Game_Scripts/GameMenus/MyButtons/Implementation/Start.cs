using System;
using GameMenus.Implementations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameMenus.MyButtons.Implementation
{
    [ButtonOfMenu(typeof(MainMenu))]
    public class Start : MyButton
    {
        protected override void OnInputConfirm()
        {
            SceneManager.LoadScene("Main_level");
        }
    }
}