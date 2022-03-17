using System;
using UnityEngine;

namespace Game_Scripts.Keys_Manager
{
    public class KeyCollectorTrigger : MonoBehaviour
    {
        private KeyController _keyController;

        private void Start()
        {
            _keyController = GetComponent<KeyController>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                _keyController.Collect();
            }
        }
    }
}