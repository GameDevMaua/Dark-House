
using UnityEngine;


namespace Player.Player_Colisions{
    public abstract class BaseColision : MonoBehaviour{
        protected string _gameTag;
        
        private void Awake() {

            _gameTag = tag;
        }

        protected abstract void defaultMethod(Collision2D other);

        protected virtual void OnEnable() {
            PlayerColisionManager.SubscribeCollisionInDictionary(_gameTag, defaultMethod);
        }
        
        protected virtual void OnDisable() {
            PlayerColisionManager.UnsubscribeCollisionInDictionary(_gameTag, defaultMethod);
        }
    }
}