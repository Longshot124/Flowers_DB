using Flowers_DB.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flowers_DB.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly FlowersDbContext _dbContext;

        public ProductViewComponent(FlowersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _dbContext.Products.ToListAsync();

            return View(products);
        }
    }
}
