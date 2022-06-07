using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookEccommerce_Admin.Models;

namespace ClassLibrary_RepositoryDLL.Repository
{
    public interface ICartRepository
    {
        List<Cart> getAllCart();
    }
}
