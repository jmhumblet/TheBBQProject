using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TheBBQProject.Data;
using TheBBQProject.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBBQProject.Controllers
{
    public class ShoppingItemController : Controller
    {
        [FromServices]
        public ShoppingCart ShoppingCart { get; set; }

        [FromServices]
        public IShoppingItemRepository ShoppingItemRepository { get; set; }

        // GET: /<controller>/
        public IActionResult Add()
        {
            return View();
        }
        
        public IActionResult AddToCart(int id)
        {
            var item = ShoppingItemRepository.Get(id);

            if (item != null)
                ShoppingCart.AddItem(item);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult RemoveFromCart(int id)
        {
            ShoppingCart.RemoveItem(id);

            return RedirectToAction("Index", "Home");
        }
    }
}
