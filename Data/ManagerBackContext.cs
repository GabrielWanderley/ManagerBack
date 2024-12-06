using ManagerBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagerBack.Data
{
    public class ManagerBackContext : DbContext
    {
        public ManagerBackContext(DbContextOptions<ManagerBackContext> opts) 
            : base(opts)
        { 
       
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

    }
}
