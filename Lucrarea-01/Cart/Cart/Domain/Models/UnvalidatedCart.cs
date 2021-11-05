using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Domain.Models
{
    public record UnvalidatedCart(string client, string quantity, string code, string address);
}
