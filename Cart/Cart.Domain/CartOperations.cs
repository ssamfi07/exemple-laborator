using Cart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Cart.Domain.Models.CartProducts;

namespace Cart.Domain
{
    public static class CartOperations
    {
        public static ICartProducts ValidatedCartProducts(Func<ClientRegistrationNumber, bool> checkClientExists, UnvalidatedCartProducts cartProducts)
        {
            List<ValidatedCart> validatedProducts = new();
            bool isValidList = true;
            string invalidReson = string.Empty;
            // go through the list of unvalidated products
            foreach(var unvalidatedProduct in cartProducts.ProductList)
            {
                // try parsing each field value of a product (address, clientregistrationNumber, code, price, quantity)
                if (!Address.TryParseAddress(unvalidatedProduct.address, out Address address))
                {
                    invalidReson = $"Invalid address ({unvalidatedProduct.client}, {unvalidatedProduct.address})";
                    isValidList = false;
                    break;
                }
                if (!Code.TryParseCode(unvalidatedProduct.code, out Code code))
                {
                    invalidReson = $"Invalid code ({unvalidatedProduct.client}, {unvalidatedProduct.code})";
                    isValidList = false;
                    break;
                }
                if (!Price.TryParsePrice(unvalidatedProduct.price, out Price price))
                {
                    invalidReson = $"Invalid price ({unvalidatedProduct.client}, {unvalidatedProduct.price})";
                    isValidList = false;
                    break;
                }
                if (!Quantity.TryParseQuantity(unvalidatedProduct.quantity, out Quantity quantity))
                {
                    invalidReson = $"Invalid quantity ({unvalidatedProduct.client}, {unvalidatedProduct.quantity})";
                    isValidList = false;
                    break;
                }
                if (!ClientRegistrationNumber.TryParseRegNum(unvalidatedProduct.client, out ClientRegistrationNumber client))
                {
                    invalidReson = $"Invalid client ({unvalidatedProduct.client}, {unvalidatedProduct.client})";
                    isValidList = false;
                    break;
                }
                ValidatedCart validProduct = new(client, quantity, price, code, address);
                validatedProducts.Add(validProduct);
            }

            if (isValidList)
            {
                return new ValidatedCartProducts(validatedProducts);
            }
            else
            {
                return new InvalidatedCartProducts(cartProducts.ProductList, invalidReson);
            }

        }

        public static ICartProducts PayCartProducts(ICartProducts cartProducts) => cartProducts.Match(
            whenEmptyCartProducts: emptyCartProducts => emptyCartProducts,
            whenUnvalidatedCartProducts: unvalidatedCartProducts => unvalidatedCartProducts,
            whenPaidCartProducts: paidCartProducts => paidCartProducts,
            whenInvalidatedCartProducts: invalidCartProducts => invalidCartProducts,
            whenValidatedCartProducts: validatedCartProducts => 
            {
                StringBuilder csv = new();
                validatedCartProducts.ProductList.Aggregate(csv, (export, cart) => export.AppendLine($"{cart.ClientRegistrationNumber.Value}, {cart.Quantity.Value}, {cart.Price.Value}, {cart.Code.Value}, {cart.Address.Value}"));

                PaidCartProducts paidCartProducts = new(validatedCartProducts.ProductList, DateTime.Now, csv.ToString());

                return paidCartProducts;
            });
    }
}
