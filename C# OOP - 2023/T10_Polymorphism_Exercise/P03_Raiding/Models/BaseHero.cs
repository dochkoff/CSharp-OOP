using P03_Raiding.Models.Interfaces;

namespace P03_Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {

        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; private set; }

        public int Power { get; private set; }

        public virtual string CastAbility() => $"{this.GetType().Name} - {Name}";
    }
}