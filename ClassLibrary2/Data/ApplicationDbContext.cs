using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentingHouseSystem.Infrastructure.Data.Models;
using RentingHouseSystem.Infrastructure.Data.SeedDb;

namespace RentingHouseSystem
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<House>()
                .HasOne(h => h.Category)
                .WithMany(c => c.Houses)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<House>()
                .HasOne(h => h.Agent)
                .WithMany(a => a.Houses)
                .HasForeignKey(h => h.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new AgentConfig());
            builder.ApplyConfiguration(new CategoryConfig());
            builder.ApplyConfiguration(new HouseConfig());

            base.OnModelCreating(builder);
        }

        public DbSet<Agent> Agents { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public  DbSet<House> Houses { get; set; } = null!;
    }
}
