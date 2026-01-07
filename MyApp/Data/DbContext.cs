using Microsoft.EntityFrameworkCore;
using MyApp.Models;


namespace MyApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Winner> Winners { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Prevent cascading deletes that cause multiple cascade paths in SQL Server.
            // Set restrict/no-action for FK relationships that point to Users.

            // Basket -> User
            modelBuilder.Entity<Basket>()
                .HasOne(b => b.User)
                .WithMany() // no navigation on User for baskets in current model
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Basket -> Gift (if you want no cascade here as well)
            modelBuilder.Entity<Basket>()
                .HasOne(b => b.Gift)
                .WithMany()
                .HasForeignKey(b => b.GiftId)
                .OnDelete(DeleteBehavior.Restrict);

            // Purchase -> User
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.User)
                .WithMany(u => u.Purchases)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Purchase -> Gift (if mapped as FK)
            modelBuilder.Entity<Purchase>()
                .HasOne<Gift>()
                .WithMany()
                .HasForeignKey("GiftId")
                .OnDelete(DeleteBehavior.Restrict);

            // Winner -> User
            modelBuilder.Entity<Winner>()
                .HasOne(w => w.User)
                .WithMany(u => u.Winner)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Winner -> Gift
            modelBuilder.Entity<Winner>()
                .HasOne(w => w.Gift)
                .WithMany()
                .HasForeignKey(w => w.GiftId)
                .OnDelete(DeleteBehavior.Restrict);

            // If Gift has a WinnerId or other FKs to Users/other tables that produced multiple paths,
            // configure them here similarly using DeleteBehavior.Restrict.
        }
    }
}