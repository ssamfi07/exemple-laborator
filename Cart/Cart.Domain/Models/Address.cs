using System;
using System.Text.RegularExpressions;

namespace Cart.Domain.Models
{
    public record Address
    {
        public string Value { get; }
        private static readonly Regex ValidPattern = new("[!@$%^&*(),?:{}|<>]$"); // string with !@$%^&*(),?:{}|<>

       // check regex (by exclusion)
        private static bool IsValid(string address) => !ValidPattern.IsMatch(address);

        public Address(string address)
        {
            if(IsValid(address))
            {
                Value = address;
            }
            else
            {
                throw new InvalidAddressException($"{address:0.##} is an invalid address value.");
            }
            Console.WriteLine($"\n\taddress: {Value}");
        }

        public static bool TryParseAddress(string stringValue, out Address address)
        {
            bool isValid = false;
            address = null;

            if (IsValid(stringValue))
            {
                isValid = true;
                address = new(stringValue);
            }

            return isValid;
        }
    }
}