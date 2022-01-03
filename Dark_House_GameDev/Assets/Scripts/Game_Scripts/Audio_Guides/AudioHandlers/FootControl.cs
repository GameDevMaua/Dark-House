using System;
using UnityEngine;

namespace Audio_Guides.AudioHandlers
{
    //[RequireComponent(typeof(AudioHandler))]
    public class FootControl : MonoBehaviour , IAudioTrigger
    {
        public bool isMoving;
        private void Update()
        {
            if (isMoving)
            {
                OnAudioTriggerEvent?.Invoke();
            }
        }

        public event Action OnAudioTriggerEvent;
    }
}