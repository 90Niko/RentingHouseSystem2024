using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentingHouseSystem.Infrastructure.Data.Models;

namespace RentingHouseSystem
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Agent> Agents { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public  DbSet<House> Houses { get; set; } = null!;
    }
}
