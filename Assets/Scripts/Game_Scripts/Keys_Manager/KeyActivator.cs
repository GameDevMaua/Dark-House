using System;
using UnityEngine;

namespace Game_Scripts.Keys_Manager
{
    public class KeyActivator : MonoBehaviour
    {
        private KeyController _keyController;

        private void Awake()
        {
            _keyController = GetComponent<KeyController>();
            _keyController.OnActivatingEvent += OnActivating;
            
        }

        private void OnActivating()
        {
            gameObject.SetActive(true);
        }
    }
}