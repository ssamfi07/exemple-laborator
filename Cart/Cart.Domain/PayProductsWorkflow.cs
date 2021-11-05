using Cart.Domain.Models;
using System;
using static Cart.Domain.Models.CartProducts;
using static Cart.Domain.CartOperations;
using static Cart.Domain.Models.CartProductsPaidEvent;

namespace Cart.Domain
{
    public class PayProductsWorkflow
    {
        public ICartProductsPaidEvent Execute(PayCartProductsCommand command, Func<ClientRegistrationNumber, bool> checkClientExists)
        {
            UnvalidatedCartProducts unvalidatedProducts = new UnvalidatedCartProducts(command.InputCartProducts);
            ICartProducts products = ValidatedCartProducts(checkClientExists, unvalidatedProducts);
            products = PayCartProducts(products);

            return products.Match(
                    whenEmptyCartProducts: emptyProducts => new CartProductsPaymentFailedEvent("Unexpected empty state") as ICartProductsPaidEvent,
                    whenUnvalidatedCartProducts: unvalidatedProducts => new CartProductsPaymentFailedEvent("Unexpected unvalidated state"),
                    whenInvalidatedCartProducts: invalidProducts => new CartProductsPaymentFailedEvent(invalidProducts.Reason),
                    whenValidatedCartProducts: validatedProducts => new CartProductsPaymentFailedEvent("Unexpected validated state"),
                    whenPaidCartProducts: paidProducts => new CartProductsPaymentSucceededEvent(paidProducts.Csv, paidProducts.PaidDate)
                );
        }
    }
}