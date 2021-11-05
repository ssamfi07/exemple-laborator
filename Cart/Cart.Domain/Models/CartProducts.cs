using CSharp.Choices;
using System;
using System.Collections.Generic;

namespace Cart.Domain.Models
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

        public record ValidatedCartProducts : ICartProducts
        {
            public ValidatedCartProducts(IReadOnlyCollection<ValidatedCart> productList)
            {
                ProductList = productList;
            }
            public IReadOnlyCollection<ValidatedCart> ProductList { get;}
        }

        public record PaidCartProducts: ICartProducts
        {
            internal PaidCartProducts(IReadOnlyCollection<ValidatedCart> productList, DateTime paidDate, string csv)
            {
                ProductList = productList;
                PaidDate = paidDate;
                Csv = csv;
            }

            public IReadOnlyCollection<ValidatedCart> ProductList { get; }
            public DateTime PaidDate { get; }
            public string Csv { get; }
        }
    }
}
