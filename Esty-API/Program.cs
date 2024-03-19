
using Esty_Applications.Contract;
using Esty_Applications.Services.BaseCategory;
using Esty_Applications.Services.BaseCategoryServices;
using Esty_Applications.Services.Category;
using Esty_Applications.Services.Login;
using Esty_Applications.Services.Order;
using Esty_Applications.Services.OrderItems;
using Esty_Applications.Services.Payment;
using Esty_Applications.Services.Product;
using Esty_Context;
using Esty_Infrastracture.BaseCategortRepository;
using Esty_Infrastracture.CategoryRepository;
using Esty_Infrastracture.OrderItemRepository;
using Esty_Infrastracture.OrderRepository;
using Esty_Infrastracture.PaymentReposatory;
using Esty_Infrastracture.ProductRepository;
using Esty_Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Esty_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
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
            }).AddApiEndpoints().AddEntityFrameworkStores<EtsyDbContext>();
            builder.Services.AddScoped<JwtHandler>();

            //For Order 
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped<IOrdersRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderServices, OrderServices>();

            //For OrderItem
            builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            builder.Services.AddScoped<IOrderItemsServices, OrderItemsServices>();

            //For Product
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductsServices, ProductsServices>();

            //For Payment
            builder.Services.AddScoped<IPayment, PaymentRepository>();
            builder.Services.AddScoped<IPaymentServices, PaymentServices>();

            // For category
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            //For BaseCategory
            builder.Services.AddScoped<IBaseCategoryServices, BaseCategoryServices>();
            builder.Services.AddScoped<IBaseCategoryRepository, BaseCategortRepository>();

            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecurityKey"]!))
                };
            }).AddBearerToken(IdentityConstants.BearerScheme); ;
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapIdentityApi<Customer>();
            app.MapControllers();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
