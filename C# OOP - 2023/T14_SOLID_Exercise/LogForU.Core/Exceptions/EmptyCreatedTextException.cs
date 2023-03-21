using System;
namespace LogForU.Core.Exceptions
{
    public class EmptyCreatedTextException : Exception
    {
        private const string DefaultMessage =
            "Created text of message cannot be null or whitespace";

        public EmptyCreatedTextException()
            : base(DefaultMessage)
        {
        }

        public EmptyCreatedTextException(string message)
            : base(message)
        {
        }
    }
}

