using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Domain
{
    public record UnvalidatedCart(string client, string quantity, string code, string address);
}
