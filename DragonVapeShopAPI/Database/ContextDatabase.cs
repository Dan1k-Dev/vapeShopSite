using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer;
using VapeShop.ClassesDb;

namespace DragonVapeShopAPI.Database
{
    public class ContextDatabase : DbContext
    {
        public DbSet<Vapess> Vapess { get; set; }
        public DbSet<Consumables> Consumables { get; set; }
        public DbSet<Liquids> Liquidss { get; set; }
        public DbSet<OnceVapes> OnceVapess { get; set; }

        public ContextDatabase(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
