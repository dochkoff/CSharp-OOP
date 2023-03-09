namespace P07_MilitaryElite.Models.Interfaces
{
    public interface IEngineer
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
    }
}