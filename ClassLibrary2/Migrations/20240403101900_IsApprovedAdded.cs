using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingHouseSystem.Infrastructure.Migrations
{
    public partial class IsApprovedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Houses",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is approved by the admin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfa4ff8c-b893-408c-aa46-f801f3fb93c6", "AQAAAAEAACcQAAAAEGrZOxdHVfsuTSMrdq2FRu6oPJniIxdzHIo3dl6OAYdaUNK1++PB39FjEpNVLSNX4g==", "c63c2b46-0fb1-4c5b-8fda-4db3f748b8c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e35f5f8d-46fe-4ff5-a9c8-4c324f1550bf", "AQAAAAEAACcQAAAAEBl9tkHP6tmDq3lQUdO/uVQGEXoo2vJIk5YytHsrG4GsglgpnFosGKYQlZeum99New==", "07c5b059-6719-40f1-a12c-e69e8a191531" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5563c5e-d780-4bce-812d-408f2c079ae2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "928d5de4-8841-44e0-a20d-ebfe18764639", "AQAAAAEAACcQAAAAECzcNGf03q4FYCOKMW1bYQmdaMnRSzHqqLCpc4kXzKGxEFqg4ovVDz99EPCB/HsxxQ==", "99d75ffc-7184-4c11-8b5b-fe84245df4be" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Houses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3eb20af-4d4c-4f06-80ea-310e54b75743", "AQAAAAEAACcQAAAAEHTSZ3kCQ4CwLUceNKaO+ylA2lhb+kga2goTkdfjppjx8icNVl3Lf4Vru8hotJQwng==", "efd71f46-bfbf-46ed-a8dc-2a87107de5ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c409eb40-a296-44a0-9746-b50ca6579c78", "AQAAAAEAACcQAAAAENOt4Dh6KIrHLiDuRPhNm7o/bW0pIYFgrzM86I/tH08/YARgWgkNjDm+RBfBdAvohQ==", "354843f9-b4ec-44ce-bc9a-086192540f21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5563c5e-d780-4bce-812d-408f2c079ae2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfd26e22-d4fa-456b-a783-a3028db91d8f", "AQAAAAEAACcQAAAAEN/tMg8fkgJoPaPW7U5e3DJPAhPhu0KwP4jhQ+De3YwAdTDzt2Ig18HFew7Q09b+vA==", "6b2c1f81-b8dd-419f-9c91-03d8f2b9005a" });
        }
    }
}
