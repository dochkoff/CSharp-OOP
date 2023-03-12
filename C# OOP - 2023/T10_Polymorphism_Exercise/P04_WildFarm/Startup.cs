
using P04_WildFarm.Core;
using P04_WildFarm.Core.Interfaces;
using P04_WildFarm.Factories;
using P04_WildFarm.Factories.Interfaces;
using P04_WildFarm.IO;
using P04_WildFarm.IO.Interfaces;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IAnimalFactory animalFactory = new AnimalFactory();
IFoodFactory foodFactory = new FoodFactory();

IEngine engine = new Engine(reader, writer, animalFactory, foodFactory);

engine.Run();