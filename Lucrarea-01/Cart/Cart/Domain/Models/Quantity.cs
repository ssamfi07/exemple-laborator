using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Domain.Models
{
    public record Quantity
    {
        public uint Quantity { get; } // how many products

        // can't buy more than 99 products at once
        private static bool IsValid(uint quantity) => quantity > 0 && quantity < 100;

        public Quantity(uint quantity)
        {
            if(IsValid(quantity))
            {
                Quantity = quantity;
            }
            else
            {
                throw new InvalidQuantityException($"{quantity:0.##} is an invalid quantity value.");
            }
            Console.WriteLine($"\n\tquantity: {Quantity}");
        }

        public override string ToString()
        {
            return $"{Quantity:0.##}";
        }

        public static bool TryParseQuantity(string quantityInput, out Quantity quantity)
        {
            bool isValid = false;
            quantity = null;
            if(uint.TryParse(quantityInput, out uint uintQuantity))
            {
                if (IsValid(uintQuantity))
                {
                    isValid = true;
                    quantity = new(uintQuantity);
                }
            }
            return isValid;
        }
    }
}