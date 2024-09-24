using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using System.Diagnostics.Metrics;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private IRepositoryManager _manager;

        public CategoryController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.Category.FindAll(false);
            return View(model);
        }
    }
}
