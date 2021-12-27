using System.Collections;
using Player.State_Machine;
using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    public class WalkingNearbyPlayerState : BaseMonsterState{
        private float _movementSpeed;
        private Vector3 _velocityVector;
        private PlayerStateMachineManager _playerStateMachinePlayer;
        private float _cooldown;
        private bool _jafoi = false;

        public override void OnStateEnter() {
            _velocityVector = (_playerSingleton.transform.position - _monsterSingleton.transform.position).normalized *
                              _movementSpeed;

            _monsterRigidbody.velocity = _velocityVector;
            
            _playerStateMachinePlayer = _playerSingleton.GetComponent<PlayerStateMachineManager>();

       
            
        }

        public override void executeState() { //todo:Esse jeito de ver se o evento já foi inscrito me parece horrível
            _cooldown -= Time.deltaTime;
            if (_cooldown <= 0 && !_jafoi) {
                Debug.Log(_cooldown);
                _jafoi = true;
                SubscribeAtOnWalkingEvent();
            }
        }

        public override void OnStateExit() {
            _playerStateMachinePlayer.WalkingPlayerState.OnWalking -= VerifyIfTheGameIsOver;
        }


        private void VerifyIfTheGameIsOver() {
                //se o player estiver dentro de um range. fim de jogo      

                var distance = (_playerSingleton.transform.position - _monsterSingleton.transform.position).magnitude;

                if (distance <= 10) { //esse 3 é meramente arbitrário
                    Debug.Log("Fim de jogo!");
                    OnStateExit();
                } 
                    

        }
         private void SubscribeAtOnWalkingEvent() {
             Debug.Log("Se inscreveu!");
             _playerStateMachinePlayer.WalkingPlayerState.OnWalking += VerifyIfTheGameIsOver;
             
        }
        
        
        public WalkingNearbyPlayerState(IStateMachineManager stateMachineManager, float movementSpeed, float cooldown) : base(stateMachineManager) {
            _movementSpeed = movementSpeed;
            _cooldown = cooldown;
        }
    }
}