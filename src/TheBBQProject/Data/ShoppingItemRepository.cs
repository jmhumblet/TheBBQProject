using System.Collections.Generic;
using System.Linq;
using TheBBQProject.Models;

namespace TheBBQProject.Data
{
    class ShoppingItemRepository : IShoppingItemRepository
    {
        private List<ShoppingItem> _data = new List<ShoppingItem>
        {
            new ShoppingItem {Id=1, Name= "Hamburger", Description= "Quality beef meat!", Price= 1.99M, Rating=3, ReviewCount = 17 },
            new ShoppingItem {Id=2, Name= "Ketchup", Description= "Tomato sauce..." , Price= 3.99M, Rating=5, ReviewCount = 1 },
            new ShoppingItem {Id=3, Name= "Mustard", Description= "Hot spicy, straight from Dijon.", Price= 2.99M, Rating=4, ReviewCount = 7 },
            new ShoppingItem {Id=4, Name= "Potatoes", Description= "You definitely need those!", Price= 0.99M, Rating=5, ReviewCount = 12 },
            new ShoppingItem {Id=5, Name= "Beer", Description= "Nice refreshing drinks. You don't want to get dehydrated!", Price= 9.99M, Rating=5, ReviewCount = 10 },
            new ShoppingItem {Id=6, Name= "Sausage", Description= "Pork and beef for your pleasure.", Price= 1.99M, Rating=2, ReviewCount = 14 },
            new ShoppingItem {Id=7, Name= "Toothpick", Description= "Get these annoying little piece of meat out of there!", Price= 0.99M, Rating=3, ReviewCount = 4 },
            new ShoppingItem {Id=8, Name= "Vegetables Mix", Description= "It's always nice to have somthing on the side...", Price= 0.99M, Rating=1, ReviewCount = 5 },
        };

        public List<ShoppingItem> Get()
        {
            return _data;
        }

        public ShoppingItem Get(int id)
        {
            return _data.Find(i => i.Id == id);
        }

        public void Add(ShoppingItem item)
        {
            if (_data.Any(i => i.Id == item.Id))
                item.Id = _data.Max(i => i.Id) + 1;
            _data.Add(item);
        }
    }
}
