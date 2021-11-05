namespace Cart.Domain.Models
{
    public record ValidatedCart(ClientRegistrationNumber ClientRegistrationNumber, Quantity Quantity, Price Price, Code Code, Address Address);
}
