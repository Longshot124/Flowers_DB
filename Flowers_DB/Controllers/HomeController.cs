using Flowers_DB.DAL;
using Flowers_DB.Models;
using Flowers_DB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
            HttpContext.Session.SetString("session", "Test");
            Response.Cookies.Append("cookie", "RZ390",new CookieOptions { Expires = DateTimeOffset.Now.AddHours(1) });

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

        //public IActionResult Basket()
        //{
        //    var session = HttpContext.Session.GetString("session");
        //    var cookie = Request.Cookies["cookie"];
        //    return NoContent();
        //}
        //public IActionResult AddToBasket(int id)
        //{
        //    var product = _dbContext.Products.Include(x => x.Category).SingleOrDefault(x => x.Id == id);

        //    if (product == null)
        //        return NotFound();
        //    var products = new List<Product>();
        //    products.Add(product);
        //    var productJson = JsonConvert.SerializeObject(products, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        //    Response.Cookies.Append("basket",productJson);

        //    return Json(products);
        //}
    }
}
