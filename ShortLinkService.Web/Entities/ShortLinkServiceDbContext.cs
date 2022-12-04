using Microsoft.EntityFrameworkCore;

namespace ShortLinkService.Web.Entities
{
    public class ShortLinkServiceDbContext : DbContext
    {
        public DbSet<LinkAlias> LinkAliases { get; set; }

        public ShortLinkServiceDbContext() : base()
        {
        }

        public ShortLinkServiceDbContext(DbContextOptions<ShortLinkServiceDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Necessary for adding migrations via CLI
        /// Example : dotnet ef migrations add "<name>"
        /// Without this method CLI throws System.InvalidOperationException 'No database provider has been configured for this DbContext'
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=ShortLinkServiceDbContext;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
