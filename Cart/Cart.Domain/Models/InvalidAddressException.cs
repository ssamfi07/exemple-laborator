using System;
using System.Runtime.Serialization;

namespace Cart.Domain
{
    [Serializable]
    internal class InvalidAddressException : Exception
    {
        public InvalidAddressException()
        {
        }

        public InvalidAddressException(string? message) : base(message)
        {
            Console.WriteLine($"{message}");
        }

        public InvalidAddressException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidAddressException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}