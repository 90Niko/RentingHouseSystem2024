using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingHouseSystem.Infrastructure.Migrations
{
    public partial class AdminAddeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e0d6de0-beec-4d4a-aad0-c6a114cecfae", "AQAAAAEAACcQAAAAEAZmwcz4F3Cy+mUY1Eo3RlYFJ6RdhgppJtoGycfJfxoai5KPt57akbZO3eRuTQ4ImQ==", "632b590e-ffd1-4f47-b3f0-26e94e945224" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f6d8099-eb7f-4175-8153-c661fde2546b", "AQAAAAEAACcQAAAAEAmONSRbolkwHPku0BCHZIMscuMFj1zVFiDoWRcJ3Lgo8Gf6Cg8kb+CTOR5Ya1bchQ==", "d599018a-ba9e-4e0e-91b5-da0ec34f1f7e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5563c5e-d780-4bce-812d-408f2c079ae2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4da10f9-4c7a-4f75-bb58-cf724d69c9c7", null, "a096ea62-efe9-4f00-92dd-6eb25e1086f6" });
        }
    }
}
