using Player.State_Machine;
using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    public class WalkingNearbyPlayerState : BaseMonsterState{
        private float _movementSpeed;
        private Vector3 _velocityVector;
        private PlayerStateMachineManager _playerStateMachinePlayer;
        private float _cooldown;
        private float _timer;
        private bool _jafoi = false;
        private float _gameOverRadious;

        public override void OnStateEnter() {
            _velocityVector = (_playerSingleton.transform.position - _monsterSingleton.transform.position).normalized *
                              _movementSpeed;

            _monsterRigidbody.velocity = _velocityVector;
            
            _playerStateMachinePlayer = _playerSingleton.GetComponent<PlayerStateMachineManager>();

            _jafoi = false;

            Timer = _cooldown;
            
            _monsterSingleton.AudioSource.Stop();

        }

        public override void executeState() { //todo:Esse jeito de ver se o evento já foi inscrito me parece horrível
            Timer -= Time.deltaTime;
            if (Timer <= 0 && !_jafoi) {
                _jafoi = true;
                SubscribeAtOnWalkingEvent();
            }
            
            var distanceFromPlayer =
                (_monsterSingleton.transform.position - _playerSingleton.transform.position).magnitude;

            if (distanceFromPlayer >= GOBackToPreSpawnStateRadiousPreSpawn) { // esse 16 é meramente ilustrativo
                _stateMachine.ChangeCurrentState(_stateMachine.PreSpawnState);
            }
            
            if(!_monsterSingleton.AudioSource.isPlaying)
                _monsterSingleton.PlayAnAudioFromAudioArray(1);
            
        }

        public override void OnStateExit() {
            _playerStateMachinePlayer.WalkingPlayerState.OnWalking -= VerifyIfTheGameIsOver;
            _monsterRigidbody.velocity = Vector2.zero;
        }


        private void VerifyIfTheGameIsOver() {
                //se o player estiver dentro de um range. fim de jogo      

                var distance = (_playerSingleton.transform.position - _monsterSingleton.transform.position).magnitude;

                if (distance <= _gameOverRadious) { //esse 10 é meramente arbitrário
                    Debug.Log("Fim de jogo!");
                    _stateMachine.ChangeCurrentState(_stateMachine.PreSpawnState);
                } 
                    

        }
         private void SubscribeAtOnWalkingEvent() {
             _playerStateMachinePlayer.WalkingPlayerState.OnWalking += VerifyIfTheGameIsOver;
             
        }

         private float Timer {
             get => _timer;
             set {
                 if (value < 0) {
                     _timer = 0;
                 }
                 else {
                     _timer = value;
                     
                 }
             }
         }

         public WalkingNearbyPlayerState(IStateMachineManager stateMachineManager, float movementSpeed, float cooldown, float gameOverRadious, float radiousPreSpawn) : base(stateMachineManager, radiousPreSpawn) {
            _movementSpeed = movementSpeed;
            _cooldown = cooldown;
            _gameOverRadious = gameOverRadious;
         }
    }
}