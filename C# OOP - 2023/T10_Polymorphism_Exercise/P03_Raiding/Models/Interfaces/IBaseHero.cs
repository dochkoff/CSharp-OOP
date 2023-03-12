using System;
namespace P03_Raiding.Models.Interfaces
{
    public interface IBaseHero
    {
        public string Name { get; }
        public int Power { get; }


        public string CastAbility();
    }
}