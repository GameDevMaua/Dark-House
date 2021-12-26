namespace Game_Scripts.Monster.State_Machine{
    public interface IStateMachineManager{
        PreSpawnState PreSpawnState { get; }
        WalkingRandomlyState WalkingRandomlyState { get; }
        WalkingNearbyPlayerState WalkingNearbyPlayerState { get; }
        BaseMonsterState CurrentState { get; }

        void ChangeCurrentState(BaseMonsterState nextState);
    }
}