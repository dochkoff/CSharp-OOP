namespace P03_Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int Power = 80;

        public Druid(string name) : base(name, Power) { }

        public override string CastAbility() => $"{base.CastAbility()} healed for {Power}";
    }
}

