using UnityEngine;

namespace Player.State_Machine{
    public class DeadState : BasePlayerState{
        private AudioSource _audioSource;
        private AudioClip _audioClip;
        
        
        public override void OnStateEnter() {
            _audioSource.clip = _audioClip;
            _audioSource.loop = false;
            _audioSource.Play();
            PlayerSingleton.Instance.SetMovingVeloctyToZero();
        }

        public DeadState(PlayerStateMachineManager playerStateMachineManager, AudioSource audioSource, AudioClip audioClip) : base(playerStateMachineManager) {
            _audioClip = audioClip;
            _audioSource = audioSource;
        }
    }
}