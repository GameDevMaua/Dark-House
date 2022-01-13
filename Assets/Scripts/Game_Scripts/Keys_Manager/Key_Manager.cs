using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Game_Scripts.Keys_Manager{
    public class Key_Manager : MonoBehaviour{
        private GameObject[] _keysList;

        [SerializeField] private int _numberOfKeys;
        
        private void Awake() {
            _keysList = GameObject.FindGameObjectsWithTag("Key");

            var totalKeys = _keysList.Length;
            
            var rdn = new Random();
            var activeKeysArray = _keysList.OrderBy(gameObj => rdn.Next()).Take(totalKeys - _numberOfKeys);

            foreach (var gameObj in activeKeysArray) {
                gameObj.SetActive(false);
            }
        }
    }
}