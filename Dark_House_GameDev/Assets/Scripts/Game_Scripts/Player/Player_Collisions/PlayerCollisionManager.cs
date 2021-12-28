using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Player_Collisions{
    public class PlayerCollisionManager : MonoBehaviour{
        private static Dictionary<string, Action<Collision2D>> _collisionDictionary = new Dictionary<string, Action<Collision2D>>();
        
        private void OnCollisionStay2D(Collision2D other) {
            string gameTag = other.gameObject.tag;

            if (_collisionDictionary.ContainsKey(gameTag)) _collisionDictionary[gameTag]?.Invoke(other);
            
            else print("Essa colisao nao esta no dicionario");
        }

        public static void SubscribeCollisionInDictionary(string key, Action<Collision2D> action) {
            if(!_collisionDictionary.ContainsKey(key)) 
                _collisionDictionary.Add(key, action);

        }
        public static void UnsubscribeCollisionInDictionary(string key) {
            if (_collisionDictionary.ContainsKey(key))
                _collisionDictionary.Remove(key);
        }
    }
}