using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingHouseSystem.Infrastructure.Migrations
{
    public partial class UserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efba08c0-66b2-4950-9f7a-38a4a46dcb16", "", "", "AQAAAAEAACcQAAAAELHiFp4LVMYifDB4ZvUx/e1hroUIzwkxnReSFoVnlN4VzHfb6V5z4j3KFid5wvvvTA==", "519ff668-6f43-4ddc-a066-37e5d5ab4ba9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db90757f-9a8d-4b98-b499-b5501955dad2", "", "", "AQAAAAEAACcQAAAAEI+pxHIQ4qjsgpLIafZwgL7JvstCbD9OYDSSBZxicztKnDbzGiEEwf+lcSOnMmyrhA==", "a35f3c8d-dece-48f2-8411-f3f4dcf85090" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

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
        }
    }
}
