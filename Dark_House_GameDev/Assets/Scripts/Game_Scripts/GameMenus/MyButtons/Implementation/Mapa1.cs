using System;
using GameMenus.Implementations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameMenus.MyButtons.Implementation
{
    [ButtonOfMenu(typeof(MainMenu))]
    public class Mapa1 : MyButton
    {
        protected override void OnInputConfirm()
        {
            SceneManager.LoadScene("Definitive_Scene");
        }
    }
}