using System;
using Player;
using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    [Serializable]
    public class MonsterStateMachineManager : MonoBehaviour, IStateMachineManager{
        private BaseMonsterState _currentState;
        private WalkingTowardsPlayerState _walkingTowardsPlayerState;
        private WalkingRoutine _walkingRoutineState;
        private SmellingState _smellingState;
        private NullState _nullState;

        [SerializeField] private float _monsterMovementSpeed;
        [SerializeField] private float _changeToMoveTowardsPlayerRadius;
        [SerializeField] private float _distanceToSmellPlayerState;
        [SerializeField] private float _smellStateDurationInSeconds;
        [SerializeField] private float _endGameCooldown;
        [SerializeField] private Transform[] _positionsRoutineArray;


        private void Awake() { //instanciar os estados e injetando suas respectivas dependências
            _walkingRoutineState = new WalkingRoutine( _positionsRoutineArray, _monsterMovementSpeed, _changeToMoveTowardsPlayerRadius);
            _walkingTowardsPlayerState = new WalkingTowardsPlayerState( _monsterMovementSpeed*1.01f, _distanceToSmellPlayerState);
            _smellingState = new SmellingState(_smellStateDurationInSeconds, _endGameCooldown);
            _nullState = new NullState();
        }

        private void Start() { //inicializando a State machine
            _currentState = _walkingRoutineState;
            _currentState.OnStateEnter();
        }

        private void Update() {
            _currentState.OnExecuteState();
        }
        
        public void ChangeCurrentState(BaseMonsterState nextState) {
            _currentState.OnStateExit();
            _currentState = nextState;
            _currentState.OnStateEnter();
        }

        #region DrawGizmos Region

        private void OnDrawGizmos() {
            var monsterPosition = MonsterSingleton.Instance.transform.position;
            
            Gizmos.color = new Color(0, 0, 1, 0.4f);
            Gizmos.DrawSphere(monsterPosition, _changeToMoveTowardsPlayerRadius); //random state radius

            Gizmos.color = new Color(1, 0, 0, 0.4f);
            Gizmos.DrawWireSphere(monsterPosition, _distanceToSmellPlayerState);//end game radius
        }
        

        #endregion
        
        public WalkingTowardsPlayerState WalkingTowardsPlayerState => _walkingTowardsPlayerState;

        public WalkingRoutine WalkingRoutineState => _walkingRoutineState;

        public BaseMonsterState CurrentState => _currentState;
        public SmellingState SmellingState => _smellingState;

        public NullState NullState => _nullState;
    }
}