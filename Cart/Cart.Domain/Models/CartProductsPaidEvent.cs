using CSharp.Choices;
using System;

namespace Cart.Domain.Models
{
    [AsChoice]
    public static partial class CartProductsPaidEvent
    {
        public interface ICartProductsPaidEvent { }

        public record CartProductsPaymentSucceededEvent : ICartProductsPaidEvent 
        {
            public string Csv{ get;}
            public DateTime PublishedDate { get; }

            internal CartProductsPaymentSucceededEvent(string csv, DateTime publishedDate)
            {
                Csv = csv;
                PublishedDate = publishedDate;
            }
        }

        public record CartProductsPaymentFailedEvent : ICartProductsPaidEvent 
        {
            public string Reason { get; }

            internal CartProductsPaymentFailedEvent(string reason)
            {
                Reason = reason;
            }
        }
    }
}