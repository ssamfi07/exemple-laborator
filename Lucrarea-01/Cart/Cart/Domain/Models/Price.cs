using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Domain.Models
{
    public record Price
    {
        public uint Price { get; }

        // price has to be positive
        private static bool IsValid(uint price) => price > 0;

        public Price(uint price)
        {
            if(IsValid(price))
            {
                Price = price;
            }
            else
            {
                throw new InvalidPriceException($"{price:0.##} is an invalid price value.");
            }
            Console.WriteLine($"\n\tprice: {Price}");
        }

        public override string ToString()
        {
            return $"{Price:0.##}";
        }

        public static bool TryParsePrice(string priceInput, out Price price)
        {
            bool isValid = false;
            price = null;
            if(uint.TryParse(priceInput, out uint uintPrice))
            {
                if (IsValid(uintPrice))
                {
                    isValid = true;
                    price = new(uintPrice);
                }
            }
            return isValid;
        }
    }
}