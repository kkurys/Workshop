using System;
using System.Runtime.Serialization;

namespace Workshop.Common.Exceptions
{
    public class InvalidCarIdException : Exception
    {
        public InvalidCarIdException()
        {
        }

        public InvalidCarIdException(string message) : base(message)
        {
        }

        public InvalidCarIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCarIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
