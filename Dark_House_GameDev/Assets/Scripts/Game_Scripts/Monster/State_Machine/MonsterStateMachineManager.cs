using System;
using Player;
using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    [Serializable]
    public class MonsterStateMachineManager : MonoBehaviour, IStateMachineManager{
        private BaseMonsterState _currentState;
        private WalkingNearbyPlayerState _walkingNearbyPlayerState;
        private WalkingRoutine _walkingRoutineState;
        private NullState _nullState;

        [SerializeField] private float _monsterMovementSpeed;
        [SerializeField] private float _lastStateCooldown;
        [SerializeField] private float _angryModeRadius;
        [SerializeField] private float _walkingEndRadius;
        [SerializeField] private float _distanceToGoBackToRoutineState;
        [SerializeField] private Transform[] _positionsRoutineArray;


        private void Awake() {
            _walkingRoutineState = new WalkingRoutine(this, _positionsRoutineArray, _monsterMovementSpeed, _angryModeRadius);
            _walkingNearbyPlayerState = new WalkingNearbyPlayerState(this, _monsterMovementSpeed*1.01f, _lastStateCooldown,_walkingEndRadius, _distanceToGoBackToRoutineState);
            _nullState = new NullState(this);
        }

        private void Start() {
            _currentState = _walkingRoutineState;
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


        private void OnDrawGizmos() {
            var monsterPosition = MonsterSingleton.Instance.transform.position;
            var playerPosition = PlayerSingleton.Instance.transform.position;
            
            Gizmos.color = new Color(0, 0, 1, 0.4f);
            Gizmos.DrawSphere(monsterPosition, _angryModeRadius); //random state radius

            Gizmos.color = new Color(1, 0, 0, 0.4f);
            Gizmos.DrawSphere(monsterPosition, _walkingEndRadius);//end game radius
            
            Gizmos.color = new Color(1, 1, 0, 0.4f);
            Gizmos.DrawWireSphere(playerPosition, _distanceToGoBackToRoutineState);//end game radius
        }


        public WalkingNearbyPlayerState WalkingNearbyPlayerState => _walkingNearbyPlayerState;

        public WalkingRoutine WalkingRoutineState => _walkingRoutineState;

        public BaseMonsterState CurrentState => _currentState;

        public NullState NullState => _nullState;
    }
}