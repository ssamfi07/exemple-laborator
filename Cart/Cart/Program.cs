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
            PayCartProductsCommand command = new(listOfProducts);
            PayProductsWorkflow workflow = new PayProductsWorkflow();
            var result = workflow.Execute(command, (registrationNumber) => true);

            result.Match(
                    whenCartProductsPaymentFailedEvent: @event =>
                    {
                        Console.WriteLine($"Payment failed: {@event.Reason}");
                        return @event;
                    },
                    whenCartProductsPaymentSucceededEvent: @event =>
                    {
                        Console.WriteLine($"Payment succeeded.");
                        Console.WriteLine(@event.Csv);
                        return @event;
                    }
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
                // this way we create an unvalidated product and add it to the list
                listOfProducts.Add(new (registrationNumber, quantityInput, code, address, priceInput));
            } while (true);
            return listOfProducts;
        }

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
