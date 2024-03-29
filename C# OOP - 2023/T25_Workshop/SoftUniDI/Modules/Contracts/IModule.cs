﻿using System;
namespace SoftUniDI.Modules.Contracts
{
    public interface IModule
    {
        void Configure();

        Type GetMapping(Type currentInterface, object attribute);

        object GetInstace(Type type);

        void SetInstance(Type implementation, object instance);
    }
}

