using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingHouseSystem.Infrastructure.Migrations
{
    public partial class UniqueqPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4c1e691-1ed3-4515-86b6-a112f47afebb", "AQAAAAEAACcQAAAAELtoUeEZNAjJUdR787pKyPW1o9yMXNli+dCgcKO7nl+cD4ZA8L0+yBwYDeXp2saobQ==", "47923b5e-9b83-40f9-92ba-fdd36fb58842" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ec2a4ac-32e2-4481-828b-3d7360aa840c", "AQAAAAEAACcQAAAAEEIPNSTg0321ZP03GFu9dpe0aCPn8vf7ryFTT+0CdpDx/wVNeBZtixk6PnVKZPxLmA==", "a602316e-ffae-44cf-b7b9-d17a25d2d60d" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b7250db-9510-47f3-8c8d-7a060e5aaafb", "AQAAAAEAACcQAAAAELoQO3BPx7WQ2FnTEUi47+MD7PcDjm8/4m/5tzlV6PmxExoLdEFqO18/724bFBDNnw==", "4100247c-28aa-4f5d-8992-1948a841c02f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61b212c8-544b-4e54-9471-13d5ec511b9b", "AQAAAAEAACcQAAAAEIQmYQoWN9mBnOoa9uAvUpahHEs306+6GHY7ag5TPPDMN2lpQL8bPlPCIf36iS3fNg==", "7185e568-6122-4492-a847-d9a483a0afbf" });
        }
    }
}
