using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Domain.Models
{
    public record Address
    {
        public string Address { get; }
        private static readonly Regex ValidPattern = new("[!@$%^&*(),?:{}|<>]$"); // string with !@$%^&*(),?:{}|<>

       // check regex (by exclusion)
        private static bool IsValid(string address) => !ValidPattern.IsMatch(address);

        public Address(string address)
        {
            if(IsValid(address))
            {
                Address = address;
            }
            else
            {
                throw new InvalidAddressException($"{address:0.##} is an invalid address value.");
            }
            Console.WriteLine($"\n\taddress: {Address}");
        }
    }
}