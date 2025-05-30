using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<EmpDbContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("EmpDbContext")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Departments}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
