using System;
using System.Text.RegularExpressions;

namespace Cart.Domain.Models
{
    public record ClientRegistrationNumber
    {
        private static readonly Regex ValidPattern = new("^CL[0-9]{5}$"); // example CL12345

        public string Value { get; }

        private static bool IsValid(string client) => ValidPattern.IsMatch(client);

        public ClientRegistrationNumber(string value)
        {
            if (ValidPattern.IsMatch(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidClientRegistrationNumberException("Client registration number format invalid");
            }
            Console.WriteLine($"\n\tClient RegNumber: {Value}");
        }

        public override string ToString()
        {
            return Value;
        }

        public static bool TryParseRegNum(string stringValue, out ClientRegistrationNumber registrationNumber)
        {
            bool isValid = false;
            registrationNumber = null;

            if (IsValid(stringValue))
            {
                isValid = true;
                registrationNumber = new(stringValue);
            }

            return isValid;
        }
    }
}
