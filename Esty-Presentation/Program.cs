using Esty_Applications.Contract;
using Esty_Applications.Services.Authentication;
using Esty_Applications.Services.Login;
using Esty_Applications.Services.Payment;
using Esty_Context;
using Esty_Infrastracture.PaymentReposatory;
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
            builder.Services.AddDbContext<EtsyDbContext>
                (option => option.UseSqlServer(Configuration.GetConnectionString("Connstr")));

            builder.Services.AddIdentity<Customer, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<EtsyDbContext>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<JwtHandler>();


            builder.Services.AddScoped<IPayment, PaymentRepository>();
            builder.Services.AddScoped<IPaymentServices, PaymentServices>(); 
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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
                pattern: "{controller=Payment}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
