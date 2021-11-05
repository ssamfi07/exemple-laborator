using System.Collections.Generic;

namespace Cart.Domain.Models
{
    public record PayCartProductsCommand
    {
        public PayCartProductsCommand(IReadOnlyCollection<UnvalidatedCart> inputCartProducts)
        {
            InputCartProducts = inputCartProducts;
        }

        public IReadOnlyCollection<UnvalidatedCart> InputCartProducts { get; }
    }
}