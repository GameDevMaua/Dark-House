
using UnityEngine;


namespace Player.Player_Collisions{
    public abstract class BaseCollision : MonoBehaviour{
        protected string _gameTag;
        
        private void Awake() {

            _gameTag = tag;
        }

        protected abstract void defaultMethod(Collision2D other);

        protected virtual void OnEnable() {
            PlayerCollisionManager.SubscribeCollisionInDictionary(_gameTag, defaultMethod);
            print(_gameTag);
        }
        
        protected virtual void OnDisable() {
            PlayerCollisionManager.UnsubscribeCollisionInDictionary(_gameTag);
        }
    }
}