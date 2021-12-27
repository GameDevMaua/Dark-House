using System;
using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    [Serializable]
    public class MonsterStateMachineManager : MonoBehaviour, IStateMachineManager{
        private BaseMonsterState _currentState;
        private PreSpawnState _preSpawnState;
        private WalkingRandomlyState _walkingRandomlyState;
        private WalkingNearbyPlayerState _walkingNearbyPlayerState;

        [SerializeField] private float _initialCooldown;
        [SerializeField] private float _initialProbability;
        [SerializeField] private float _monsterMovementSpeed;
        [SerializeField] private float _lastStateCooldown;
        
        
        private void Awake() {
            _preSpawnState = new PreSpawnState(this, _initialCooldown, _initialProbability);
            _walkingRandomlyState = new WalkingRandomlyState(this, _monsterMovementSpeed);
            _walkingNearbyPlayerState = new WalkingNearbyPlayerState(this, _monsterMovementSpeed*1.01f, _lastStateCooldown);
        }

        private void Start() {
            _currentState = PreSpawnState;
            _currentState.OnStateEnter();
        }

        private void Update() {
            _currentState.executeState();
        }
        
        public void ChangeCurrentState(BaseMonsterState nextState) {
            _currentState.OnStateExit();
            _currentState = nextState;
            _currentState.OnStateEnter();
        }
        
        
        public PreSpawnState PreSpawnState => _preSpawnState;
        
        public WalkingRandomlyState WalkingRandomlyState => _walkingRandomlyState;
        
        public WalkingNearbyPlayerState WalkingNearbyPlayerState => _walkingNearbyPlayerState;

        public BaseMonsterState CurrentState => _currentState;
        
    }
}