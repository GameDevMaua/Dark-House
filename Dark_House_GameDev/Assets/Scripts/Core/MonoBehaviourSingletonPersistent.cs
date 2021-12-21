using UnityEngine;

namespace Core
{
    public class MonoBehaviourSingletonPersistent<T> : MonoBehaviour
        where T : Component
    {
        private static T _instance;
        public static T Instance {
            get
            {
                if (_instance == null)
                {
                    print("NewInstance");
                    _instance = new GameObject("Test").AddComponent<T>();
                    return _instance;
                }
                else
                {
                    return _instance;
                }
                
            } 
        }
	
        
        public virtual void Awake ()
        {
            if (_instance == null) {
                _instance = this as T;
                DontDestroyOnLoad (this);
            } else {
                Destroy (gameObject);
            }
        }
    }
}