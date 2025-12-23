using Furni.App.Contexts;
using Furni.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Furni.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        readonly FurniDbContext _context;

        public ProductController(FurniDbContext context)
        {
            _context = context;
        }

        [HttpGet] //admin/product
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/create")]//admin/product/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/create")]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid) return View(product);
            product.CreatedDate = DateTime.UtcNow.AddHours(4);
            product.IsDeleted = false;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("delete/{id}")] //asp-route-id = @Model.Id
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null) return NotFound("Product is not found!");
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
