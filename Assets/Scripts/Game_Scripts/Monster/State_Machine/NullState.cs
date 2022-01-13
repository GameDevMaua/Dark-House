using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    public class NullState : BaseMonsterState{
        public override void OnStateEnter() {
            _monsterRigidbody.velocity = Vector3.zero;
            _monsterSingleton.AudioSource.Stop();
        }

        public NullState() {
        }
    }
}