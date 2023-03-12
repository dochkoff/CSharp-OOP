using P03_Raiding.Models.Interfaces;

namespace P03_Raiding.Factory.Interfaces
{
    public interface IHeroFactory
    {
        IBaseHero Create(string type, string name);
    }
}