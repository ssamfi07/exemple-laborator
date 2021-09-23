using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Domain
{
    public record ValidatedCart(ClientRegistrationNumber ClientRegistrationNumber, Product Product);
}
