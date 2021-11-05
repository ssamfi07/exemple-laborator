using System;
using System.Runtime.Serialization;

namespace Cart.Domain
{
    [Serializable]
    internal class InvalidClientRegistrationNumberException : Exception
    {
        public InvalidClientRegistrationNumberException()
        {
        }

        public InvalidClientRegistrationNumberException(string? message) : base(message)
        {
            Console.WriteLine($"{message}");
        }

        public InvalidClientRegistrationNumberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidClientRegistrationNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}