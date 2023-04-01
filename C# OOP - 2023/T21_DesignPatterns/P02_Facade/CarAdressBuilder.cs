using System;
namespace P02_Facade
{
    public class CarAdressBuilder : CarBuilderFacade
    {
        public CarAdressBuilder(Car car)
        {
            Car = car;
        }

        public CarAdressBuilder InCity(string city)
        {
            Car.City = city;
            return this;
        }

        public CarAdressBuilder AtAdress(string adress)
        {
            Car.Adress = adress;
            return this;
        }
    }
}

