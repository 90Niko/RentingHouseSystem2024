using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentingHouseSystem.Infrastructure.Data.Models;

namespace RentingHouseSystem.Infrastructure.Data.SeedDb
{
    internal class UserConfig: IEntityTypeConfiguration<AplicationUser>
    {
        public void Configure(EntityTypeBuilder<AplicationUser> builder)
        {
            var data = new SeedData();

            builder.HasData(new AplicationUser[] { data.AgentUser, data.GuestUser });
        }
    }
}
