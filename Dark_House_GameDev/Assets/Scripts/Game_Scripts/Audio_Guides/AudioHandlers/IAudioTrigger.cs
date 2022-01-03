using System;

namespace Audio_Guides.AudioHandlers
{
    public interface IAudioTrigger
    {
        public event Action OnAudioTriggerEvent;
    }
}