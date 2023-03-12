namespace P03_Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int Power = 80;

        public Rogue(string name) : base(name, Power) { }

        public override string CastAbility() => $"{base.CastAbility()} hit for {Power} damage";
    }
}

