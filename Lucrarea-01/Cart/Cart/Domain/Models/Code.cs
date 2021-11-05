using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Domain.Models
{
    public record Code
    {
        public string Code { get; }
        private static readonly Regex ValidPattern = new("^[0-9]{5}$"); // ex 12345

       // check regex
        private static bool IsValid(string code) => ValidPattern.IsMatch(code);

        public Code(string code)
        {
            if(IsValid(code))
            {
                Code = code;
            }
            else
            {
                throw new InvalidCodeException($"{code:0.##} is an invalid code value.");
            }
            Console.WriteLine($"\n\tcode: {Code}");
        }
    }
}