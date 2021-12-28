using UnityEngine;

namespace GameMenus.MyButtons
{
    public class MyNullButton : MyButton
    {
        private static MyNullButton _instace;
        public static MyNullButton Instance
        {
            get
            {

                if (_instace is null)
                {
                    _instace = FindObjectOfType<MyNullButton>();
                }

                if (_instace is null)
                {
                    var gameObj = new GameObject("NullButton");
                    _instace = gameObj.AddComponent<MyNullButton>();
                }

                return _instace;
            }
        }

    }
}