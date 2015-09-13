using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBBQProject.Models;

namespace TheBBQProject.Data
{
    public interface IShoppingItemRepository
    {
        List<ShoppingItem> Get();
        ShoppingItem Get(int id);
        void Add(ShoppingItem item);
    }
}
