using System;
using System.Linq;
using System.Reflection;
using System.Text;
using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private UserRepository users;
        private VehicleRepository vehicles;
        private RouteRepository routes;

        public Controller()
        {
            users = new();
            vehicles = new();
            routes = new();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            var allUsers = users.GetAll();

            foreach (var user in allUsers)
            {
                if (user.DrivingLicenseNumber == drivingLicenseNumber)
                {
                    return String.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
                }
            }

            User driver = new User(firstName, lastName, drivingLicenseNumber);
            users.AddModel(driver);

            return String.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (vehicleType != "CargoVan" && vehicleType != "PassengerCar")
            {
                return String.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            var allVehicles = vehicles.GetAll();
            foreach (var vehicle in allVehicles)
            {
                if (vehicle.LicensePlateNumber == licensePlateNumber)
                {
                    return String.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
                }
            }

            if (vehicleType == "CargoVan")
            {
                CargoVan cargoVan = new(brand, model, licensePlateNumber);
                vehicles.AddModel(cargoVan);
            }

            if (vehicleType == "PassengerCar")
            {
                PassengerCar passengerCar = new(brand, model, licensePlateNumber);
                vehicles.AddModel(passengerCar);
            }

            return String.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            var allRoutes = routes.GetAll();
            foreach (var route in allRoutes)
            {
                if (route.StartPoint == startPoint
                    && route.EndPoint == endPoint
                    && route.Length == length)
                {
                    return String.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
                }
            }

            foreach (var route in allRoutes)
            {
                if (route.StartPoint == startPoint
                    && route.EndPoint == endPoint
                    && route.Length < length)
                {
                    return String.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
                }
            }

            int routeId = allRoutes.Count + 1;
            Route route1 = new(startPoint, endPoint, length, routeId);
            routes.AddModel(route1);

            var allRoutesAgain = routes.GetAll();
            foreach (var route in allRoutesAgain)
            {
                if (route.StartPoint == startPoint
                    && route.EndPoint == endPoint
                    && route.Length > route1.Length)
                {
                    route.LockRoute();

                }
            }

            return String.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);

        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            User user = users.FindById(drivingLicenseNumber);
            Vehicle vehicle = vehicles.FindById(licensePlateNumber);
            Route route = routes.FindById(routeId);

            if (user.IsBlocked == true)
            {
                return String.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }
            if (vehicle.IsDamaged == true)
            {
                return String.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }
            if (route.IsLocked == true)
            {
                return String.Format(OutputMessages.RouteLocked, routeId);
            }



            vehicle.Drive(route.Length);

            if (isAccidentHappened == true)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }

        public string RepairVehicles(int count)
        {
            var demagedCars = vehicles.GetAll().Where(v => v.IsDamaged == true).OrderBy(x => x.Brand).ThenBy(x => x.Model).Take(count);

            int mycount = 0;
            foreach (var car in demagedCars)
            {
                car.ChangeStatus();
                car.Recharge();
                mycount++;
            }

            return String.Format(OutputMessages.RepairedVehicles, mycount);
        }

        public string UsersReport()
        {
            StringBuilder sb = new();

            sb.AppendLine("*** E-Drive-Rent ***");

            var allUsers = users.GetAll().OrderByDescending(u => u.Rating).ThenBy(u => u.LastName).ThenBy(u => u.FirstName);

            foreach (var user in allUsers)
            {
                sb.AppendLine(user.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

