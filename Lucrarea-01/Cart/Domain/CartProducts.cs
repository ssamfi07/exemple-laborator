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

        public record UnvalidatedCartProducts : ICartProducts
        {
            public UnvalidatedCartProducts(IReadOnlyCollection<UnvalidatedCart> productList)
            {
                ProductList = productList;
            }
            public IReadOnlyCollection<UnvalidatedCart> ProductList { get;}
        }

        public record InvalidatedCartProducts : ICartProducts
        {
            internal InvalidatedCartProducts(IReadOnlyCollection<UnvalidatedCart> productList, string reason)
            {
                ProductList = productList;
                Reason = reason;
            }
            public IReadOnlyCollection<UnvalidatedCart> ProductList { get; }
            public string Reason { get; }
        }

        public record ValidatedCartProducts(IReadOnlyCollection<ValidatedCart> ProductList) : ICartProducts;

        public record PaidCartProducts(IReadOnlyCollection<ValidatedCart> ProductList, DateTime PaidDate) : ICartProducts;
    }
}
