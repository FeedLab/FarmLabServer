using FarmLabService.DataObjects;
using Microsoft.EntityFrameworkCore;

namespace FarmLabService.Dal
{
    public class FarmLabContext : DbContext
    {
        public FarmLabContext(DbContextOptions<FarmLabContext> options)
            : base(options)
        { }

        public DbSet<UserItem> User{ get; set; }
        public DbSet<FarmItem> Farm { get; set; }
        public DbSet<SessionItem> Session { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserItem>()
                .HasOne(a => a.ActiveSession)
                .WithOne(b => b.User)
                .HasForeignKey<SessionItem>(b => b.UserId);

            modelBuilder.Entity<SessionItem>()
                .HasOne(a => a.User)
                .WithOne(b => b.ActiveSession)
                .HasForeignKey<UserItem>(b => b.SessionId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
