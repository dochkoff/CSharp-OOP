using System;
namespace FakeAxeAndDummy
{
    public interface IWeapon
    {
        public int AttackPoints { get; set; }
        public int DurabilityPoints { get; set; }


        void Attack(ITarget target);
    }
}

