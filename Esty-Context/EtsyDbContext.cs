using Esty_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Context
{
    public class EtsyDbContext: IdentityDbContext <Customer>
    {
        public DbSet<Payments> payment { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<BaseCategory> baseCategories { get; set; }
        public DbSet <Category> categories { get; set; }
        public DbSet <Orders> orders { get; set; }
        public DbSet <OrderItem> orderItems { get; set; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public EtsyDbContext(DbContextOptions<EtsyDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EtsyDbContext).Assembly);
        }
    }
}
