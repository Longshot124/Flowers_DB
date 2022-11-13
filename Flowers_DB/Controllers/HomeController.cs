using Flowers_DB.DAL;
using Flowers_DB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flowers_DB.Controllers
{
    public class HomeController : Controller
    {
        private readonly FlowersDbContext _dbContext;

        public HomeController(FlowersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var sliderImages = _dbContext.SliderImages.ToList();
            var slider = _dbContext.Sliders.SingleOrDefault();
            var category = _dbContext.Categories.ToList();
            var products = _dbContext.Products.ToList();

            var homeViewModel = new HomeViewModel
            {
                SliderImages = sliderImages,
                Slider = slider,
                Categories = category,
                Products = products
            };
            return View(homeViewModel);
        }
    }
}
