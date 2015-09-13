using System.Linq;
using Microsoft.AspNet.Mvc;
using TheBBQProject.Models;

namespace TheBBQProject.ViewComponents
{
    //[ViewComponent(Name = "ShopppingCart")]
    public class ShoppingCartViewComponent : ViewComponent
    {
        private ShoppingCart _cart;
        public ShoppingCartViewComponent(ShoppingCart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            if (!_cart.CartItems.Any())
                return View("Empty");

            return View(_cart);
        }
    }
}
