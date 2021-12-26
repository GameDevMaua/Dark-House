using System;
using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    [Serializable]
    public class StateMachineManager : MonoBehaviour, IStateMachineManager{
        private BaseMonsterState _currentState;
        private PreSpawnState _preSpawnState;
        private WalkingRandomlyState _walkingRandomlyState;
        private WalkingNearbyPlayerState _walkingNearbyPlayerState;

        [SerializeField] private float _initialCooldown;
        [SerializeField] private float _initialProbability;
        
        
        private void Awake() {
            _preSpawnState = new PreSpawnState(this, _initialCooldown, _initialProbability);
            _walkingRandomlyState = new WalkingRandomlyState(this);
            _walkingNearbyPlayerState = new WalkingNearbyPlayerState(this);
        }

        private void Start() {
            _currentState = PreSpawnState;
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