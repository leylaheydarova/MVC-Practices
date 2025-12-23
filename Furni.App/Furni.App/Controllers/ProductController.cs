using Furni.App.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Furni.App.Controllers
{
    public class ProductController : Controller
    {
        readonly FurniDbContext _context;

        public ProductController(FurniDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            return View(_context.Products.AsQueryable().ToList());
        }


    }
}
