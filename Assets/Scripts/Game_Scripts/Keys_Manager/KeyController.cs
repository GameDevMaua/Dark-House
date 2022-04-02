using System;
using UnityEngine;

namespace Game_Scripts.Keys_Manager
{
    public class KeyController : MonoBehaviour
    {
        public event Action OnCollectingEvent;
        public event Action OnActivatingEvent;
        public event Action OnDeActivatingEvent;
        
        private bool _currentActive;
        private bool _collected;

        public void SetActive()
        {
            if (_currentActive)
            {
                return;
            }
            _currentActive = true;
            OnActivatingEvent?.Invoke();
        }

        public void SetFalse()
        {
            _currentActive = false;
            OnDeActivatingEvent?.Invoke();
            
            // todo: fazer todos os gameobjs começarem ativos, e dps com essa função e a função de cima, setar tudo para os sons tocarem corretamente
            // e quando tiver sido coletado tocar um som diferente
            // quando desativado tocar outro som
        }

        public void Collect()
        {
            if (_collected)
                return;
            
            _collected = true;
            OnCollectingEvent?.Invoke();
        }


        public bool CurrentActive => _currentActive;

        public bool Collected => _collected;
    }
}