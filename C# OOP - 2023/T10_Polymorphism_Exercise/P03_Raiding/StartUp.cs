using P03_Raiding.Core;
using P03_Raiding.Core.Interfaces;
using P03_Raiding.Factory;
using P03_Raiding.Factory.Interfaces;
using P03_Raiding.IO;
using P03_Raiding.IO.Interfaces;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IHeroFactory heroFactory = new HeroFactory();

IEngine engine = new Engine(reader, writer, heroFactory);

engine.Run();