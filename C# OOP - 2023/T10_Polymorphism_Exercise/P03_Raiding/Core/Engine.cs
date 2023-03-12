using P03_Raiding.Core.Interfaces;
using P03_Raiding.Factory.Interfaces;
using P03_Raiding.IO.Interfaces;
using P03_Raiding.Models.Interfaces;

namespace P03_Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory heroFactory;

        private readonly ICollection<IBaseHero> heroes;

        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;

            heroes = new List<IBaseHero>();
        }

        public void Run()
        {
            int heroesCount = int.Parse(reader.ReadLine());

            while (heroes.Count < heroesCount)
            {
                try
                {
                    heroes.Add(CreateHero());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(reader.ReadLine());
            int raidGroupPower = 0;

            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
                raidGroupPower += hero.Power;
            }

            writer.WriteLine(Battle(bossPower, raidGroupPower));

        }

        private string Battle(int bossPower, int raidGroupPower)
        {
            if (raidGroupPower >= bossPower)
            {
                return "Victory!";
            }
            else
            {
                return "Defeat...";
            }
        }

        private IBaseHero CreateHero()
        {
            string name = reader.ReadLine();
            string type = reader.ReadLine();

            return heroFactory.Create(type, name);
        }
    }
}