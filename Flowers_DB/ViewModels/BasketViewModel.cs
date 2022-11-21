using Flowers_DB.Models;

namespace Flowers_DB.ViewModels
{
    public class BasketViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public int Count { get; set; }

        

        
       
    }
}
