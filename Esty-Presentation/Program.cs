using Esty_Applications.Contract;
using Esty_Applications.Services.Authentication;
using Esty_Applications.Services.BaseCategory;
using Esty_Applications.Services.BaseCategoryServices;
using Esty_Applications.Services.Category;
using Esty_Applications.Services.Login;
using Esty_Applications.Services.Order;
using Esty_Applications.Services.Payment;
using Esty_Applications.Services.Product;
using Esty_Context;
using Esty_Infrastracture.BaseCategortRepository;
using Esty_Infrastracture.CategoryRepository;
using Esty_Infrastracture.OrderRepository;
using Esty_Infrastracture.PaymentReposatory;
using Esty_Infrastracture.ProductRepository;
using Esty_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;


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
            // For category
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            //For Product
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductsServices, ProductsServices>();
            //For BaseCategory
            builder.Services.AddScoped<IBaseCategoryServices, BaseCategoryServices>();
            builder.Services.AddScoped<IBaseCategoryRepository, BaseCategortRepository>();
            builder.Services.AddScoped<IOrdersRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderServices, OrderServices>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //For Localization--===>>>>
            builder.Services.AddControllersWithViews();

            builder.Services.AddLocalization();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            builder.Services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    factory.Create(typeof(JsonStringLocalizerFactory));
                });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo(name: "en-US"),
                    new CultureInfo(name: "ar-EG")
                };

                options.DefaultRequestCulture = new RequestCulture(culture : supportedCultures[0], uiCulture : supportedCultures[0]);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            /////===========>>>>>>




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            //Localization------>>>>>>>
            var supportedCultures = new[] { "ar-EG","en-US" };
            var localizationOptions = new RequestLocalizationOptions()
                //.SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);
            /////--------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>


            app.UseAuthorization();
        
            app.MapControllerRoute(
                name: "default",
						//pattern: "{controller=Home}/{action=Index}/{id?}");
						pattern: "{controller=Login}/{action=Index}/{id?}");


			app.Run();
        }
    }
}
