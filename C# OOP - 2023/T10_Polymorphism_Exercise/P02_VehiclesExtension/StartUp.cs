using P02_VehiclesExtension.Core;
using P02_VehiclesExtension.Core.Interfaces;
using P02_VehiclesExtension.Factory;
using P02_VehiclesExtension.Factory.Interfaces;
using P02_VehiclesExtension.IO;
using P02_VehiclesExtension.IO.Interfaces;
using P02_VehiclesExtension.Models;
using P02_VehiclesExtension.Models.Interfaces;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IVehicleFactory vehicleFactory = new VehicleFactory();

IEngine engine = new Engine(reader, writer, vehicleFactory);

engine.Run();