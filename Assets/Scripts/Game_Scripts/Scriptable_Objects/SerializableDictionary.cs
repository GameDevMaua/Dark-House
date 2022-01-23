using System.Collections.Generic;
using UnityEngine;

namespace Game_Scripts.Scriptable_Objects{
    public abstract class SerializableDictionary<K,V> : ScriptableObject{
        public List<K> keyList;
        public List<V> valueList;
    
        public Dictionary<K, V> dictionary;

        protected virtual void OnEnable() {
            dictionary = new Dictionary<K, V>();
            for (var i = 0; i < keyList.Count; i++) {
                dictionary.Add(keyList[i], valueList[i]);
            }
        }
    
        protected virtual void OnDisable() {
            dictionary = new Dictionary<K, V>();
            for (var i = 0; i < keyList.Count; i++) {
                dictionary.Add(keyList[i], valueList[i]);
            }
        }
    }
}
