using System;
using Audio_Guides.AudioHandlers;
using UnityEngine;

public class WallDetetion : MonoBehaviour , IAudioTrigger
{
    // [SerializeField] private AudioHandler _audioHandler;
    //
    // // Start is called before the first frame update
    // void Start()
    // {
    //     _audioHandler = GetComponent<AudioHandler>();
    // }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.name == "player" && other.gameObject.GetComponent<BasicMoviment>().direction.magnitude != 0)
        {
            OnAudioTriggerEvent?.Invoke();
        }
    }
    
    public event Action OnAudioTriggerEvent;
}
