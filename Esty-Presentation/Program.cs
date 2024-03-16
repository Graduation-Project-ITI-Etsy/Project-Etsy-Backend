using Esty_Context;
using Esty_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Esty_Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var Configuration = builder.Configuration;
            builder.Services.AddDbContext<Context>(option => option.UseSqlServer(Configuration.GetConnectionString("Connstr")));
            builder.Services.AddControllersWithViews();
            builder.Services.AddIdentity<Customer,IdentityRole>().
                AddEntityFrameworkStores<Context>().
                AddDefaultTokenProviders();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
