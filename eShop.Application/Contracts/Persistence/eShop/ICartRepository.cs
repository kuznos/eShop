using eShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Contracts.Persistence.eShop
{
    public interface ICartRepository : IAsyncRepository<Cart>
    {
    }
}
