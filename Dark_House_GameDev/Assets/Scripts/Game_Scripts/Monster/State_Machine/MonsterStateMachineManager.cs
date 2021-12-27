using System;
using Player;
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
        [SerializeField] private float _spawnAroundPlayerRadious;
        [SerializeField] private float _walkingRandomlyRadious;
        [SerializeField] private float _walkingNearbyPlayerRadious;
        [SerializeField] private float _deactivateAndGoToPreSpanwStateRadious;


        private void Awake() {
            _preSpawnState = new PreSpawnState(this, _initialCooldown, _initialProbability, _deactivateAndGoToPreSpanwStateRadious);
            _walkingRandomlyState = new WalkingRandomlyState(this, _monsterMovementSpeed, _spawnAroundPlayerRadious,_walkingRandomlyRadious,_deactivateAndGoToPreSpanwStateRadious);
            _walkingNearbyPlayerState = new WalkingNearbyPlayerState(this, _monsterMovementSpeed*1.01f, _lastStateCooldown,_walkingNearbyPlayerRadious, _deactivateAndGoToPreSpanwStateRadious);
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


        private void OnDrawGizmos() {
            var monsterPosition = MonsterSingleton.Instance.transform.position;
            var playerPosition = PlayerSingleton.Instance.transform.position;
            
            Gizmos.color = new Color(0, 0, 1, 0.4f);
            Gizmos.DrawSphere(monsterPosition, _walkingRandomlyRadious); //random state radious

            Gizmos.color = new Color(1, 0, 0, 0.4f);
            Gizmos.DrawSphere(monsterPosition, _walkingNearbyPlayerRadious);//nearby state radious

            Gizmos.color = new Color(1, 1, 0, 0.4f);
            Gizmos.DrawWireSphere(playerPosition, _spawnAroundPlayerRadious); //Spawn around player raidious

            Gizmos.color = new Color(1, 0, 1, 0.4f);
            Gizmos.DrawWireSphere(playerPosition, _deactivateAndGoToPreSpanwStateRadious);
        }

        public PreSpawnState PreSpawnState => _preSpawnState;
        
        public WalkingRandomlyState WalkingRandomlyState => _walkingRandomlyState;
        
        public WalkingNearbyPlayerState WalkingNearbyPlayerState => _walkingNearbyPlayerState;

        public BaseMonsterState CurrentState => _currentState;
        
    }
}