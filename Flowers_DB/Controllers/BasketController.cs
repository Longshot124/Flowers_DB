using Flowers_DB.DAL;
using Flowers_DB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Flowers_DB.Controllers
{
    public class BasketController : Controller
    {
        private readonly FlowersDbContext _dbContext;

        public BasketController(FlowersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Basket()
        {
           var basketItems = GetBasketItems();
            return View(basketItems);

        }
        public async Task< IActionResult> AddToBasket(int? productId)
        {
            if (productId is null) return BadRequest();
            var product = await _dbContext.Products.Where(p => p.Id == productId).FirstOrDefaultAsync();
            if(product is null) return NotFound();

            var basket = Request.Cookies["basket"];
            var basketItems = new List<BasketViewModel>();
            var basketItem = new BasketViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Count = 1
            };

            if (basket is null)
            {
                
                basketItems.Add(basketItem);
            }
            else
            {
                basketItems = JsonConvert.DeserializeObject<List<BasketViewModel>>(basket);
                var existProduct =  basketItems.Where(b => b.Id == product.Id).FirstOrDefault();
                if (existProduct is null) basketItems.Add(basketItem);
                else existProduct.Count += 1;
            }
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(5);
            Response.Cookies.Append("basket",JsonConvert.SerializeObject(basketItems), option);

            return Ok();
        }

        public async Task<IActionResult> GetBasketCount()
        {
            var basketItems = GetBasketItems();
            return Ok(basketItems.Count);
        }

        private List<BasketViewModel> GetBasketItems()
        {
            var basket = Request.Cookies["basket"];
            var basketItems = basket is not null
                ? JsonConvert.DeserializeObject<List<BasketViewModel>>(basket) 
                : new List<BasketViewModel>();

            return basketItems;
        }
    }
}
