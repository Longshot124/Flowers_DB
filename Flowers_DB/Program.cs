using Flowers_DB.DAL;
using Microsoft.EntityFrameworkCore;

namespace Flowers_DB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews().AddNewtonsoftJson(opt=>opt.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            builder.Services.AddMvc();
            builder.Services.AddDbContext<FlowersDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddSession(opt => opt.IdleTimeout = TimeSpan.FromMinutes(1));
            var app = builder.Build();

            app.UseStaticFiles();
            app.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
            app.UseSession();
            app.Run();
        }
    }
}