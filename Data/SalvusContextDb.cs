using Salvus.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Salvus.Data
{
    public class SalvusContextDb : IdentityDbContext
    {
        public SalvusContextDb(DbContextOptions<SalvusContextDb> opt) : base(opt)
        {
            
        }

        public DbSet<Coin> Coins { get; set; }

        public DbSet<Asset> Assets { get; set;}
    }
}