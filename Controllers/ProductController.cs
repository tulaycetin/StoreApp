using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using System.Linq;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServicesManager _manager;

        public ProductController(IServicesManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.ProductServices.GetAllProducts(false);
            return View(model);
        }

        public IActionResult Get([FromRoute(Name ="id")]int id)
        {
            var model = _manager.ProductServices.GetOneProduct(id,false);

            return View(model);
           
        }
    }
}