using System;

namespace Events{
    public static class EventManager{
        public static event Action OnGameOver;
        public static event Action OnGameWin;

        public static void InvokeOnPlayerDeath() {
            OnGameOver?.Invoke();
        }

        public static void InvokeOnGameWin() {
            OnGameWin?.Invoke();
        }
        
    }
}