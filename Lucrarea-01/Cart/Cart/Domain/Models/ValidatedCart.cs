using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Domain.Models
{
    public record ValidatedCart(ClientRegistrationNumber ClientRegistrationNumber, Quantity Quantity, Price Price, Code Code, Address Address);
}
