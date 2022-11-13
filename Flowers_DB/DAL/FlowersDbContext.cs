using Flowers_DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Flowers_DB.DAL
{
    public class FlowersDbContext:DbContext
    {
        public FlowersDbContext(DbContextOptions<FlowersDbContext> option) : base(option)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }

    }
}
