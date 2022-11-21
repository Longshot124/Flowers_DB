using Flowers_DB.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flowers_DB.Controllers
{
    public class ProductController : Controller
    {
        private readonly FlowersDbContext _dbContext;

        public ProductController(FlowersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var products = _dbContext.Products.Include(c=>c.Category).ToList();
            return View(products);
        }
        public IActionResult DiscountProduct()
        {
            var products = _dbContext.Products.Include(c => c.Category).ToList();
            return View(products);
        }
        public IActionResult Details(int? Id)
        {
            if (Id is null) return BadRequest();
            
            var product = _dbContext.Products.Include(c=>c.Category).SingleOrDefault(x=>x.Id == Id);
            if (product is null) return NotFound();
            
            return View(product);
        }
       

    }
}
