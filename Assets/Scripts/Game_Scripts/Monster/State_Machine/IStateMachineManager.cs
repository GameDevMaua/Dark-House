namespace Game_Scripts.Monster.State_Machine{
    public interface IStateMachineManager{
        WalkingTowardsPlayerState WalkingTowardsPlayerState { get; }
        WalkingRoutine WalkingRoutineState { get; }
        
        SmellingState SmellingState { get; }
        BaseMonsterState CurrentState { get; }
        NullState NullState { get; }

        void ChangeCurrentState(BaseMonsterState nextState);
    }
}