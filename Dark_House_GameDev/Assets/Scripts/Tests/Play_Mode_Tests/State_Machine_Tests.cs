using System.Collections;
using Game_Scripts.Monster.State_Machine;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using Player;
using UnityEngine;
using UnityEngine.TestTools;

public class State_Machine_Tests
{

    [UnityTest]
    public IEnumerator it_should_be_3_units_away_from_player_when_in_WalkingRandomlyState_enter()
    {
        var stateMachine = Substitute.For<StateMachineManager>();
        var walkingState = new WalkingRandomlyState(stateMachine);

        var resultVector = walkingState.TeleportToNextPlayerRandomly(3);
        var distance = (PlayerSingleton.Instance.transform.position - resultVector).magnitude;

        yield return null;
        Assert.AreEqual(3, distance);         
        
    }
}
