using System;
using LogForU.Core.Layouts.Interfaces;

namespace LogForU.Factories.Interfaces
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}

