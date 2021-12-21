using UnityEngine;

namespace Player{
    public class PlayerKeyInventory : MonoBehaviour{

        private static int _keyCountInInventory = 0;
        
        public static int KeyCount {
            get => _keyCountInInventory;
        }
        
        public static void AddOneKey() {
            _keyCountInInventory++;
        }
    }
}