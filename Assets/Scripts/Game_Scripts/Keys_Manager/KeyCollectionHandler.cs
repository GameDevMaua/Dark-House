using System;
using UnityEngine;

namespace Game_Scripts.Keys_Manager
{
    public class KeyCollectionHandler : MonoBehaviour
    {
        private KeyController _keyController;

        private void Start()
        {
            _keyController = GetComponent<KeyController>();
            _keyController.OnCollectingEvent += OnCollecting;
        }

        private void OnCollecting()
        {
            
        }
    }
}