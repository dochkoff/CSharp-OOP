
using P02_Facade;

Car car = new CarBuilderFacade()
    .Info
        .WithType("Toyota")
        .WithColor("Silver")
        .WithNumberOfDoors(4)
    .BuildAdress
        .InCity("Tokio")
        .AtAdress("Nojizu Sanatochi 88")
    .Build();

Console.WriteLine(car);
