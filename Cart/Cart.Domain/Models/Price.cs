using System;

namespace Cart.Domain.Models
{
    public record Price
    {
        public decimal Value { get; }

        // price has to be positive
        private static bool IsValid(decimal price) => price > 0;

        public Price(decimal price)
        {
            if(IsValid(price))
            {
                Value = price;
            }
            else
            {
                throw new InvalidPriceException($"{price:0.##} is an invalid price value.");
            }
            Console.WriteLine($"\n\tprice: {Value}");
        }

        public override string ToString()
        {
            return $"{Value:0.##}";
        }

        public static bool TryParsePrice(string priceInput, out Price price)
        {
            bool isValid = false;
            price = null;
            if(decimal.TryParse(priceInput, out decimal decimalPrice))
            {
                if (IsValid(decimalPrice))
                {
                    isValid = true;
                    price = new(decimalPrice);
                }
            }
            return isValid;
        }
    }
}