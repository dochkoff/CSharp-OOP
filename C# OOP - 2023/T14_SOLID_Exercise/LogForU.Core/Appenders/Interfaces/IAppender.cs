using System;
using LogForU.Core.Enums;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Models.Interfaces;

namespace LogForU.Core.Appenders.Interfaces
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        public int MessageAppended { get; }

        void AppendMessage(IMessage message);
    }
}

