namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var builder = WebApplication.CreateBuilder(args);
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //var app = builder.Build();
            WebApplication app = builder.Build();

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
                pattern: "{controller=Default}/{action=Index}/{id?}")
                //pattern: "{controller=Default}/{action=Index}/{id?}/{a?}/{b?}/{c?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
