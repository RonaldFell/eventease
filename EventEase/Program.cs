using Microsoft.EntityFrameworkCore;

namespace EventEase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // code used to connect to the SQL Server using the connection string "DefaultConnection"
            builder.Services.AddDbContext<EventEase.Data.ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Registers MVC services (controllers + views) to the app
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            
            if (!app.Environment.IsDevelopment())
            {
                
                app.UseExceptionHandler("/Home/Error");

                
                app.UseHsts();
            }

            app.UseHttpsRedirection(); 
            app.UseStaticFiles();       

            app.UseRouting();           
            app.UseAuthorization();    

            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run(); // Start the app
        }
    }
}
