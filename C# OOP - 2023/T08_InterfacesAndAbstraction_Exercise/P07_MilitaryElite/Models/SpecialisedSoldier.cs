using System;
using P07_MilitaryElite.Enums;
using P07_MilitaryElite.Models.Interfaces;

namespace P07_MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps { get; private set; }

        public override string ToString()
        => base.ToString() + $"{Environment.NewLine}Corps: {Corps}";
    }
}