
using Esty_Applications.Contract;
using Esty_Applications.Services.Authentication;
using Esty_Applications.Services.BaseCategory;
using Esty_Applications.Services.BaseCategoryServices;
using Esty_Applications.Services.Category;
using Esty_Applications.Services.Login;
using Esty_Applications.Services.Order;
using Esty_Applications.Services.OrderItems;
using Esty_Applications.Services.Payment;
using Esty_Applications.Services.Product;
using Esty_Context;
using Esty_Context.DataSeed;
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
using Microsoft.OpenApi.Models;
using System.Text;

namespace Esty_API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddCors(op =>
            {
                op.AddPolicy("Default", policy =>
                {
                    //policy.WithOrigins("http://localhost:4200,null").WithMethods("get,post").WithHeaders("xyz");
                    policy.AllowAnyHeader().
                           AllowAnyMethod().
                           AllowAnyOrigin();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JWTToken_Auth_API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });
            var Configuration = builder.Configuration;

            //the configration of database connection string 
            builder.Services.AddDbContext<EtsyDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Connstr"),
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.CommandTimeout(60); 
            }), ServiceLifetime.Scoped);




            builder.Services.AddIdentity<Customer, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
            }).AddApiEndpoints().AddEntityFrameworkStores<EtsyDbContext>();
            //for Jwt Configration and add authentication for my project 
            builder.Services.AddAuthentication(op =>
            {
                op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(op =>
            {
                op.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:Key"]))

                };
            });
            //for Customer Service to authentication
            builder.Services.AddScoped<IAuthService, AuthService>();
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


            var app = builder.Build();


            //Date Seeding//
            var Scope = app.Services.CreateScope();
            var services = Scope.ServiceProvider;
            var dbContext = services.GetRequiredService<EtsyDbContext>();

            var LoggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                await dbContext.Database.MigrateAsync();
                await DataSeedContext.DataSeedingAsync(dbContext);
            }
            catch (Exception ex)
            {
                var Logger = LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex, "Error in Migration");
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("Default");

            app.MapControllers();

            app.Run();
        }
    }
}
