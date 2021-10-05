using Salvus.Models;
using Microsoft.EntityFrameworkCore;

namespace Salvus.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
            
        }

        public DbSet<Coin> coins { get; set; }
    }
}