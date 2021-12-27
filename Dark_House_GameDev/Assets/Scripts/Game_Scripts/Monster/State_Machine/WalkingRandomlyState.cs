using UnityEngine;


namespace Game_Scripts.Monster.State_Machine{
    
    
    public class WalkingRandomlyState : BaseMonsterState{

        private float _monsterSpeedMagnitude;
        private Vector3 _monsterSpeedVector;

        private Player.State_Machine.PlayerStateMachineManager _playerStateMachinePlayer;
        
        public override void OnStateEnter() {

            _playerStateMachinePlayer = _playerSingleton.GetComponent<Player.State_Machine.PlayerStateMachineManager>();

            
            _playerStateMachinePlayer.WalkingPlayerState.OnWalking += changeState; //Se inscrever no evento
            

            //posionar o monstro
           TeleportMonster(RandomVectorAroundPlayer(3)); //esse raio de tamanho 3 é meramente arbitrário
           
           //Verificar se velocidade é válida
           var isItGoingToCollideWithPlayer = true;
           
           while(isItGoingToCollideWithPlayer) {
               var randomSpeedVector = RandomVectorGenerator(_monsterSpeedMagnitude);

               isItGoingToCollideWithPlayer = CheckIfItsGoingToCollideWithPlayer(randomSpeedVector);

               _monsterSpeedVector = randomSpeedVector; 
           }

           //aplicar velocidade

           _monsterRigidbody.velocity = _monsterSpeedVector;

        }
        

        public Vector3 RandomVectorAroundPlayer(float radius) {
            var t = Random.Range(0f, 360f);
            var xPosition = _playerSingleton.transform.position.x + radius * Mathf.Cos(t);
            var yPosition = _playerSingleton.transform.position.y + radius * Mathf.Sin(t);

            return new Vector3(xPosition, yPosition, 0);
        }

        

        private bool CheckIfItsGoingToCollideWithPlayer(Vector3 direction) {
            var monsterPosition = _monsterSingleton.transform.position;
            var hit = Physics2D.Raycast(monsterPosition, direction, Mathf.Infinity, LayerMask.GetMask("Player"));

            return hit;

        }

        private Vector3 RandomVectorGenerator(float magnitude) {
            var randomX = Random.Range(-360f, 360f);
            var randomY = Random.Range(-360f, 360f);

            var randomVector = new Vector3(randomX, randomY, 0f);

            var outputVector = randomVector.normalized;

            outputVector *= magnitude;

            return outputVector;
        }

        private void TeleportMonster(Vector3 destiny) {
            _monsterSingleton.transform.position = destiny;
        }


        public override void executeState() {
            //Verifica se o player faz barulho
            //Caso positivo, verifica a distância
            //Se o player estiver no raio pré-determinado por mim, muda para o estado Walking Nearby Player
            
        }

        public void changeState() {
            var distance = (_monsterSingleton.transform.position - _playerSingleton.transform.position).magnitude;
            
            if(distance <= 10) //esse três é o raio em que o monstro irá ouvir o player. Esse número é meramente arbitrário
                _stateMachine.ChangeCurrentState(_stateMachine.WalkingNearbyPlayerState);
        }

        public override void OnStateExit() {
            _playerStateMachinePlayer.WalkingPlayerState.OnWalking -= changeState;
        }


        public WalkingRandomlyState(IStateMachineManager stateMachineManager, float monsterSpeedMagnitude) : base(stateMachineManager) {
            _monsterSpeedMagnitude = monsterSpeedMagnitude;
        }
    }
}

