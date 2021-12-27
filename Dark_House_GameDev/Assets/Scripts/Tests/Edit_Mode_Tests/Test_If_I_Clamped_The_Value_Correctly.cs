using Game_Scripts.Monster.State_Machine;
using NSubstitute;
using NUnit.Framework;

namespace Tests{
    public class Test_If_I_Clamped_The_Value_Correctly{
        [Test]
        public void if_i_pass_a_value_less_than_zero_it_should_be_zero() {
            var preSpawnState = new PreSpawnState(null, 10f, 4f,10f);
            
            preSpawnState.CooldownToCheckSpawn = -4f;
            
            Assert.AreEqual(0f,preSpawnState.CooldownToCheckSpawn);
        }

        [Test]
        public void if_its_already_zero_and_i_subtract_one_should_be_zero() {
            var preSpawnState = new PreSpawnState(null, 0f, 4f, 10f);
            preSpawnState.CooldownToCheckSpawn--;
            
            Assert.AreEqual(0f, preSpawnState.CooldownToCheckSpawn);
        }
        
        [Test]
        public void if_its_already_zero_and_i_subtract_ten_should_be_zero() {
            var preSpawnState = new PreSpawnState(null, 0f, 4f,10f);
            preSpawnState.CooldownToCheckSpawn -= 10f;
            
            Assert.AreEqual(0f, preSpawnState.CooldownToCheckSpawn);
        }
        
    }
}