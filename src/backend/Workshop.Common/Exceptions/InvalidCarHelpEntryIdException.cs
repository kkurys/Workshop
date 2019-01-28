using System;
using System.Runtime.Serialization;

namespace Workshop.Common.Exceptions
{
    public class InvalidCarHelpEntryIdException : Exception
    {
        public InvalidCarHelpEntryIdException()
        {
        }

        public InvalidCarHelpEntryIdException(string message) : base(message)
        {
        }

        public InvalidCarHelpEntryIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCarHelpEntryIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}