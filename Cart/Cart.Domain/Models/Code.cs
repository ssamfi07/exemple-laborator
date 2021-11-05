using System;
using System.Text.RegularExpressions;

namespace Cart.Domain.Models
{
    public record Code
    {
        public string Value { get; }
        private static readonly Regex ValidPattern = new("^[0-9]{5}$"); // ex 12345

       // check regex
        private static bool IsValid(string code) => ValidPattern.IsMatch(code);

        public Code(string code)
        {
            if(IsValid(code))
            {
                Value = code;
            }
            else
            {
                throw new InvalidCodeException($"{code:0.##} is an invalid code value.");
            }
            Console.WriteLine($"\n\tcode: {Value}");
        }

        public static bool TryParseCode(string stringValue, out Code code)
        {
            bool isValid = false;
            code = null;

            if (IsValid(stringValue))
            {
                isValid = true;
                code = new(stringValue);
            }

            return isValid;
        }
    }
}