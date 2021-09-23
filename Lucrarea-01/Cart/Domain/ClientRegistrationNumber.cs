using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cart.Domain
{
    public record ClientRegistrationNumber
    {
        private static readonly Regex ValidPattern = new("^CL[0-9]{5}$"); // example CL12345

        public string Value { get; }

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
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
