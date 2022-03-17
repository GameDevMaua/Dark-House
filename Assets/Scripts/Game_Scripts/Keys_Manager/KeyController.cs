using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game_Scripts.Keys_Manager
{
    public class KeyController : MonoBehaviour
    {
        public event Action OnCollectingEvent;
        public event Action OnActivatingEvent;
        
        private bool _currentActive;
        private bool _collected;

        public void SetActive()
        {
            if (_currentActive)
            {
                return;
            }
            _currentActive = true;
            OnActivatingEvent?.Invoke();
        }

        public void Collect()
        {
            if (_collected)
                return;
            
            _collected = true;
            OnCollectingEvent?.Invoke();
        }
    }
}