using P07_MilitaryElite.Enums;

namespace P07_MilitaryElite.Models.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }
        State State { get; }

        void CompleteMission();
    }
}

