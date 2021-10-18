using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Domain
{
    public record Product
    {
        public int Quantity { get; }
        public decimal Price { get; }
        public string Code { get; }
        public string Address { get; }

        public Product(string quantity, decimal price, string code, string address)
        {
            // try parsing the quantity from string to Int32
            try
            {
                Quantity = Int32.Parse(quantity);
            }
            catch
            {
                Quantity = 0;
                throw new InvalidQuantityException($"{quantity:0.##} is an invalid quantity value.");
            }

            // try parsing the price from string to decimal
            try
            {
                Price = Convert.ToDecimal(price);
            }
            catch
            {
                Price = 0;
                throw new InvalidPriceException($"{price:0.##} is an invalid quantity value.");
            }

            if (!string.IsNullOrEmpty(code)) // add some regex maybe
            {
                Code = code;
            }
            else
            {
                throw new InvalidCodeException($"{code:0.##} is an invalid code value.");
            }

            if (!string.IsNullOrEmpty(address)) // add some regex maybe
            {
                Address = address;
            }
            else
            {
                throw new InvalidAddressException($"{address:0.##} is an invalid address value.");
            }

            Console.WriteLine($"\nNew Product with \n\tquantity: {Quantity}\n\tcode: {Code}\n\taddress: {Address}");
        }

        public override string ToString()
        {
            return $"{Quantity:0.##}";
        }

        public static bool TryParseQuantity(string gradeString, out Grade grade)
        {
            bool isValid = false;
            grade = null;
            if(decimal.TryParse(gradeString, out decimal numericGrade))
            {
                if (IsValid(numericGrade))
                {
                    isValid = true;
                    grade = new(numericGrade);
                }
            }

            return isValid;
        }
    }
}
