using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Game_Scripts.Keys_Manager{
    public class KeyManager : Singleton<KeyManager> {
        private readonly List<KeyController> _keysList = new List<KeyController>();

        public event Action<KeyController> ActivatedEvent;
        public event Action<KeyController> CollectedEvent;
        
        
        [SerializeField] private int numberOfKeys;
        private void Awake() 
        {
            foreach (Transform childTransform in transform)
            {
                var keyController = childTransform.GetComponent<KeyController>();
                if (keyController)
                {
                    _keysList.Add(keyController);
                }
            }
            
            var newKeyControllers = _keysList.OrderBy(controller => Random.value).Take(numberOfKeys);
            
            foreach (var keyController in newKeyControllers)
            {
                keyController.OnActivatingEvent += () => { ActivatedEvent?.Invoke(keyController); };
                keyController.OnCollectingEvent += () => { CollectedEvent?.Invoke(keyController); };
                
                keyController.SetActive();
            }
        }
    }
}