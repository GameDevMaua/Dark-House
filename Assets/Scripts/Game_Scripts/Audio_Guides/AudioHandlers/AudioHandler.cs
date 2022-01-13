using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Audio_Guides.AudioHandlers
{
    public class AudioHandler : MonoBehaviour
    {
        [SerializeField]
        private List<AudioClip> list = new List<AudioClip>();


        public bool isPlaying;
        protected AudioSource _audioSource;

        public float timeAfterFinish;
        public event Action SoundFinishedPlayingEvent;
        //public event Action SoundStartedPlayingEvent;


        private IEnumerator WaitForSound()
        {
            yield return new WaitUntil(() => _audioSource.isPlaying == false);
            yield return new WaitForSeconds(timeAfterFinish);
            isPlaying = false;
            SoundFinishedPlayingEvent?.Invoke();
        }

        private AudioSource GetAudioSource()
        {
            _audioSource ??= GetComponentInChildren<AudioSource>() ?? gameObject.AddComponent<AudioSource>();
            return _audioSource;
        }

        private IEnumerable<IAudioTrigger> GetAudioTriggers()
        {
              var a = GetComponents<IAudioTrigger>().ToList();
            a.AddRange( GetComponentsInChildren<IAudioTrigger>() );
            return a;
        }
        
        [ContextMenu("play random clip")]
        private void PlayRandomClip()
        {
            if (list.Count <=0 )
            {
                Debug.LogWarning("no clip to play in audioHandler");
                return;
            }
            var index = Random.Range(0, list.Count);
            var clip = list[index];

            var audioSource = GetAudioSource();
            if (isPlaying)
                return;
            audioSource.PlayOneShot(clip);
            isPlaying = true;
            StartCoroutine(WaitForSound());

        }


        private void OnTriggeringAudio()
        {
            PlayRandomClip();
        }

        private void Start()
        {
            
            foreach (var triggerBase in GetAudioTriggers())
            {
                triggerBase.OnAudioTriggerEvent += OnTriggeringAudio;
            }
            
        }
    }
}