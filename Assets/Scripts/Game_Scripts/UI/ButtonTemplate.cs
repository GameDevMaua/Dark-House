using UnityEngine;
using UnityEngine.UI;

namespace GameMenus
{
    public abstract class ButtonTemplate : MonoBehaviour
    {
        private Button _button;
        protected  Animator sceneDarker;
        protected virtual void Start()
        {
            sceneDarker = GameObject.Find("BlackCover").GetComponent<Animator>();
            _button = GetComponentInChildren<Button>();
            _button.onClick.AddListener(OnButtonClicked);
        }

        protected abstract void OnButtonClicked();
    }
}