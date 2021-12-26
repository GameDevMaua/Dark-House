using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    
    
    public class WalkingRandomlyState : BaseMonsterState{
        public override void OnStateEnter() {
            //determinar onde irá nascer e a velocidade

           TeleportMonster(TeleportToNextPlayerRandomly(3)); //esse raio de tamanho 3 é meramente arbitrário
        }

        public Vector3 TeleportToNextPlayerRandomly(float radius) {
            var t = Random.Range(0f, 360f);
            var xPosition = _playerSingleton.transform.position.x + radius * Mathf.Cos(t);
            var yPosition = _playerSingleton.transform.position.y + radius * Mathf.Sin(t);

            return new Vector3(xPosition, yPosition, 0);
        }


        public override void executeState() {
            //aplicar a velocidade no singleton do monstro
            
        }

        private void TeleportMonster(Vector3 destiny) {
            _monsterSingleton.transform.position = destiny;
        }
        
        public WalkingRandomlyState(IStateMachineManager stateMachineManager) : base(stateMachineManager) {
        }
    }
}

/*
 *Para saber se o player fez barulho de novo, podemos usar o observer pattern para emitir um evento quando o player
 * sair do estado "Idle" para o estado "Walking"
 *
 * quando isso ocorrer, nós atualizamos o estado do monstro para "Walking Nearby Player"
 */