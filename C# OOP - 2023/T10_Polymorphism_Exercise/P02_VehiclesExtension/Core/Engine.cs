using System;
using System.Collections.Generic;
using P02_VehiclesExtension.Core.Interfaces;
using P02_VehiclesExtension.Factory.Interfaces;
using P02_VehiclesExtension.IO.Interfaces;
using P02_VehiclesExtension.Models;
using P02_VehiclesExtension.Models.Interfaces;

namespace P02_VehiclesExtension.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private readonly ICollection<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;

            vehicles = new List<IVehicle>();
        }

        public void Run()
        {
            vehicles.Add(CreateVehicle()); //car
            vehicles.Add(CreateVehicle()); //truck
            vehicles.Add(CreateVehicle()); //bus

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }

        private void ProcessCommand()
        {
            string[] commandsTockens = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commanType = commandsTockens[0];
            string vehicleType = commandsTockens[1];
            double amount = double.Parse(commandsTockens[2]);

            IVehicle currentVehicle = vehicles.FirstOrDefault(cv => cv.GetType().Name == vehicleType);

            if (currentVehicle == null)
            {
                Console.WriteLine("There is no such a vehicle.");
            }

            if (commanType == "Drive")
            {
                Console.WriteLine(currentVehicle.Drive(amount, true));
            }
            else if (commanType == "DriveEmpty")
            {
                Console.WriteLine(currentVehicle.Drive(amount, false));
            }
            else if (commanType == "Refuel")
            {
                currentVehicle.Refuel(amount);
            }
        }

        private IVehicle CreateVehicle()
        {
            string[] props = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return vehicleFactory.Create(props[0], double.Parse(props[1]), double.Parse(props[2]), double.Parse(props[3]));
        }
    }
}

