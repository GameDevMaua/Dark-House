using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game_Scripts.GameMenus
{
    [RequireComponent(typeof(EventSystem))]
    public class SelectionController : MonoBehaviour
    {
        private EventSystem _eventSystem;
        private GameObject _nullButton;

        private void Start()
        {
            _eventSystem = GetComponent<EventSystem>();
            _nullButton = GameObject.Find("NullButton");
            if (_nullButton is null)
            {
                Debug.LogError("no gameObject called 'NullButton' ");
            }
        }

        private void Update()
        {
            if (_eventSystem.currentSelectedGameObject == null)
            {
                _eventSystem.SetSelectedGameObject(_nullButton);
            }
        }
    }
}