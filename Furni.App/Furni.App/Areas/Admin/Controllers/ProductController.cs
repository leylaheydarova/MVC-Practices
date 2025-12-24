using Furni.App.Contexts;
using Furni.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid) return View(product);
            product.CreatedDate = DateTime.UtcNow.AddHours(4);
            product.IsDeleted = false;
            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("product/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound("Poduct is not found!");
            _context.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("update")]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound("Product is not found");
            return View(product);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(Product product)
        {
            if (!ModelState.IsValid) return View(product);
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (existingProduct == null) return NotFound("Product is not found");
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.CreatedDate = product.CreatedDate;
            existingProduct.IsDeleted = product.IsDeleted;
            existingProduct.ImageName = product.ImageName;
            existingProduct.ImageUrl = product.ImageUrl;
            existingProduct.UpdateDate = DateTime.UtcNow.AddHours(4);
            _context.Products.Update(existingProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("toggle/{id}")]
        public async Task<IActionResult> Toggle([FromRoute] int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound("Product is not found");
            product.IsDeleted = !product.IsDeleted;
            _context.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
