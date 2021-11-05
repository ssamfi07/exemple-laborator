namespace Cart.Domain.Models
{
    public record UnvalidatedCart(string client, string quantity, string code, string address, string price);
}
