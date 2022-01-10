using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Game_Scripts.GameMenus
{
    public class ButtonSoundPlayer: MonoBehaviour , ISelectHandler, IDeselectHandler
    {
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponentInChildren<AudioSource>();
            if (_audioSource is null)
            {
                Debug.LogWarning("no audio source found on this gameObject");
            }
        }

        public void OnSelect(BaseEventData eventData)
        {
            _audioSource?.Play();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            _audioSource?.Stop();
        }
    }
}