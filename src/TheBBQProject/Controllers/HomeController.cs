using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;
using TheBBQProject.Data;
using TheBBQProject.Models;

namespace TheBBQProject.Controllers
{
    public class HomeController : Controller
    {


        [FromServices]
        public IShoppingItemRepository _shoppingRepository
        {
            get; set;
        }


        private MyConfiguration _configuration;

        public HomeController(IShoppingItemRepository repository)
        {
            _shoppingRepository = repository;
        }
        public IActionResult Index()
        {
            ViewBag.MyVar = _configuration.MyVar;
            var myobject = _configuration.MyObject;
            var items = _shoppingRepository.Get();

            return View(items);
        }


        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
        
        public IActionResult New()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult New(ShoppingItem newItem)
        {
            return RedirectToAction("Index");
        }
    }
}
