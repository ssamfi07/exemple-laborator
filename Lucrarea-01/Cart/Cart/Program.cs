using System;
using System.Collections.Generic;
using Cart.Domain;
using Cart.Domain.Models;
using static Cart.Domain.Models.CartProducts;

namespace Cart
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            // EmptyCartProducts emptyCartProducts = new ();
            var listOfProducts = ReadListOfProducts().ToArray();
            UnvalidatedCartProducts unvalidatedCartProducts = new(listOfProducts);
            ICartProducts result = ValidateCartProducts(unvalidatedCartProducts);
            result.Match(
                whenEmptyCartProducts: emptyResult => emptyCartProducts,
                whenUnvalidatedCartProducts: unvalidatedResult => unvalidatedCartProducts,
                whenPaidCartProducts: paidResult => paidResult,
                whenInvalidatedCartProducts: invalidResult => invalidResult,
                whenValidatedCartProducts: validatedResult => PayCartProducts(validatedResult)
            );

            Console.WriteLine("Program end");
        }

        private static List<UnvalidatedCart> ReadListOfProducts()
        {
            List <UnvalidatedCart> listOfProducts = new();
            do
            {
                //read client registration number and products and create a list of products
                var registrationNumber = ReadValue("Registration Number: ");
                if (string.IsNullOrEmpty(registrationNumber))
                {
                    break;
                }

                var quantityInput = ReadValue("Quantity: ");
                if (string.IsNullOrEmpty(quantityInput))
                {
                    break;
                }

                var priceInput = ReadValue("Price: ");
                if (string.IsNullOrEmpty(priceInput))
                {
                    break;
                }

                var code = ReadValue("Code: ");
                if (string.IsNullOrEmpty(code))
                {
                    break;
                }

                var address = ReadValue("Address: ");
                if (string.IsNullOrEmpty(address))
                {
                    break;
                }

                try
                {
                    // ClientRegistrationNumber client = new ClientRegistrationNumber(registrationNumber);
                    // Product prod = new Product(quantityInput, code, address);
                    // this way we create an unvalidated product and add it to the list
                    listOfProducts.Add(new (registrationNumber, quantityInput, priceInput, code, address));
                }
                catch
                {
                    throw new InvalidProductException("Input error at creating a new Product");
                }
            } while (true);
            return listOfProducts;
        }

        // here we need to access the list elements and decide if each entry is valid
        // private static ICartProducts ValidateCartProducts(UnvalidatedCartProducts unvalidatedProducts) =>
        //     random.Next(100) > 50 ?
        //     new InvalidatedCartProducts(new List<UnvalidatedCart>(), "Random error")
        //     : new ValidatedCartProducts(new List<ValidatedCart>());

        // private static ICartProducts ValidateCartProducts2(UnvalidatedCartProducts unvalidatedProducts) =>
        //     random.Next(100) > 50 ?
        //     new InvalidatedCartProducts(new List<UnvalidatedCart>(), "Random error")
        //     : new ValidatedCartProducts(new List<ValidatedCart>());

        // private static ICartProducts PayCartProducts(ValidatedCartProducts validCartProducts) =>
        //     new PaidCartProducts(new List<ValidatedCart>(), DateTime.Now);

            
        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
