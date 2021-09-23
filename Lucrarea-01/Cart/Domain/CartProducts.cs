using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Domain
{
    // choice type for 
    [AsChoice]
    public static partial class CartProducts
    {
        public interface ICartProducts { }

        public record EmptyCartProducts() : ICartProducts;

        public record UnvalidatedCartProducts(IReadOnlyCollection<UnvalidatedCart> ProductList) : ICartProducts;

        public record InvalidatedCartProducts(IReadOnlyCollection<UnvalidatedCart> ProductList, string reason) : ICartProducts;

        public record ValidatedCartProducts(IReadOnlyCollection<ValidatedCart> ProductList) : ICartProducts;

        public record PaidCartProducts(IReadOnlyCollection<ValidatedCart> ProductList, DateTime PaidDate) : ICartProducts;
    }
}
