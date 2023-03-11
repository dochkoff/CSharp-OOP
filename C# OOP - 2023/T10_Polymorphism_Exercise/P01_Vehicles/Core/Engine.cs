using System;
using System.Collections.Generic;
using P01_Vehicles.Core.Interfaces;
using P01_Vehicles.Factory.Interfaces;
using P01_Vehicles.IO.Interfaces;
using P01_Vehicles.Models;
using P01_Vehicles.Models.Interfaces;

namespace P01_Vehicles.Core
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

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
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
                    Console.WriteLine(currentVehicle.Drive(amount));
                }
                else if (commanType == "Refuel")
                {
                    currentVehicle.Refuel(amount);
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }

        private IVehicle CreateVehicle()
        {
            string[] props = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return vehicleFactory.Create(props[0], double.Parse(props[1]), double.Parse(props[2]));
        }
    }
}

