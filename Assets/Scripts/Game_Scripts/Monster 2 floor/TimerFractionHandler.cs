using System;
using UnityEngine;

namespace DefaultNamespace.Monster_2_floor{
    [Serializable]
    public class TimerFractionHandler{
        private int _indexMax;
        private float _maxTime = 50f;

       [SerializeField] private bool[] _boolsList;
        public event Action<int> TimerIndexEvent;

        public void Set(int indexMax, float maxTime) {
            _indexMax = indexMax;
            _maxTime = maxTime;

            _boolsList = new bool[indexMax];
        }

        public void UpdateNotUnity(float currentTime) {
            int currentIndex =  Mathf.FloorToInt(_indexMax * currentTime / _maxTime);
            if(currentIndex >= _indexMax) return;
            
            if (!_boolsList[currentIndex]) {
                TimerIndexEvent?.Invoke(currentIndex);

                for (var i = currentIndex; i >= 0; i--) {
                    _boolsList[i] = true;
                }
            }    
        }
    }
}