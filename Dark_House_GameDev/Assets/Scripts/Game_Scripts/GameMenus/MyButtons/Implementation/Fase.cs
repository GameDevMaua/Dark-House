using UnityEngine.SceneManagement;

namespace GameMenus.MyButtons.Implementation
{
    // [ButtonOfMenu(typeof(MainMenu))]
    public class Fase : MyButton
    {
        protected override void OnInputConfirm()
        {
            SceneManager.LoadScene("Main_level");
        }
    }
}