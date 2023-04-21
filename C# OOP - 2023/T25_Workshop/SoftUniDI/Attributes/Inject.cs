﻿using System;
namespace SoftUniDI.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]
    public class Inject : Attribute
    {
        public Inject(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}

