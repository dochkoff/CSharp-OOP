using P03_Raiding.Factory.Interfaces;
using P03_Raiding.Models;
using P03_Raiding.Models.Interfaces;

namespace P03_Raiding.Factory
{
    public class HeroFactory : IHeroFactory
    {
        public HeroFactory()
        {
        }

        public IBaseHero Create(string type, string name)
        {
            switch (type)
            {
                case "Druid":
                    return new Druid(name);
                case "Paladin":
                    return new Paladin(name);
                case "Rogue":
                    return new Rogue(name);
                case "Warrior":
                    return new Warrior(name);
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }
    }
}

