namespace Original
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://127.0.0.1:5500/Frontend.html")   
                          .WithHeaders("Content-Type", "Authorization", "X-Requested-With")  
                          .WithMethods("GET", "POST", "PUT");  
                });
            });

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseRouting();

            app.UseCors("AllowFrontend");

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

        }
    }
}
