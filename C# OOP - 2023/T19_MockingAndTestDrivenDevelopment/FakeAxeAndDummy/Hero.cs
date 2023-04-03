using System;

namespace FakeAxeAndDummy
{
    public class Hero
    {


        public Hero(string name, IWeapon weapon)
        {
            Name = name;
            Experience = 0;
            Weapon = weapon;
        }

        public string Name { get; set; }
        public int Experience { get; set; }
        public IWeapon Weapon { get; set; }


    }
}