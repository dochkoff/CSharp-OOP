using System;
namespace P02_Facade
{
    public class CarBuilderFacade
    {
        protected Car Car { get; set; }

        public CarBuilderFacade()
        {
            Car = new Car();
        }

        public CarInfoBuilder Info => new CarInfoBuilder(Car);
        public CarAdressBuilder BuildAdress => new CarAdressBuilder(Car);

        public Car Build() => Car;
    }
}

