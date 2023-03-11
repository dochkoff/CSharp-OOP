using P01_Vehicles.Core;
using P01_Vehicles.Core.Interfaces;
using P01_Vehicles.Factory;
using P01_Vehicles.Factory.Interfaces;
using P01_Vehicles.IO;
using P01_Vehicles.IO.Interfaces;
using P01_Vehicles.Models;
using P01_Vehicles.Models.Interfaces;
using System.Linq;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IVehicleFactory vehicleFactory = new VehicleFactory();

IEngine engine = new Engine(reader, writer, vehicleFactory);

engine.Run();