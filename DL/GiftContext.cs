using Entities;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class GiftContext : DbContext
    {
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<User> Users { get; set; }

        public GiftContext(DbContextOptions<GiftContext> options):base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }
    }
}
