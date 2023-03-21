using System;
using LogForU.Core.Layouts;
using LogForU.Core.Layouts.Interfaces;
using LogForU.CustomLayouts;
using LogForU.Factories.Interfaces;

namespace LogForU.Factories
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            switch (type)
            {
                case "SimpleLayout": return new SimpleLayout();
                case "XmlLayout": return new XmlLayout();
                default: throw new InvalidOperationException("Invalid layout type");
            }
        }
    }
}

