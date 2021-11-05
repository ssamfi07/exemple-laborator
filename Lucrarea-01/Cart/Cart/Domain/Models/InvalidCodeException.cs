using System;
using System.Runtime.Serialization;

namespace Cart.Domain
{
    [Serializable]
    internal class InvalidCodeException : Exception
    {
        public InvalidCodeException()
        {
        }

        public InvalidCodeException(string? message) : base(message)
        {
            Console.WriteLine($"{message}");
        }

        public InvalidCodeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}