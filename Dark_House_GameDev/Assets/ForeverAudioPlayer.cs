using System;
using System.Collections;
using System.Collections.Generic;
using Audio_Guides.AudioHandlers;
using UnityEngine;

public class ForeverAudioPlayer : MonoBehaviour , IAudioTrigger
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnAudioTriggerEvent?.Invoke();
    }

    public event Action OnAudioTriggerEvent;
}
