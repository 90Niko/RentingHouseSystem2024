using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingHouseSystem.Infrastructure.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e0d6de0-beec-4d4a-aad0-c6a114cecfae", "Guest", "Guestov", "AQAAAAEAACcQAAAAEAZmwcz4F3Cy+mUY1Eo3RlYFJ6RdhgppJtoGycfJfxoai5KPt57akbZO3eRuTQ4ImQ==", "632b590e-ffd1-4f47-b3f0-26e94e945224" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f6d8099-eb7f-4175-8153-c661fde2546b", "Agent", "Agentov", "AQAAAAEAACcQAAAAEAmONSRbolkwHPku0BCHZIMscuMFj1zVFiDoWRcJ3Lgo8Gf6Cg8kb+CTOR5Ya1bchQ==", "d599018a-ba9e-4e0e-91b5-da0ec34f1f7e" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f5563c5e-d780-4bce-812d-408f2c079ae2", 0, "b4da10f9-4c7a-4f75-bb58-cf724d69c9c7", "admin@mail.com", false, "Great", "Admin", false, null, "admin@mail.com", "admin@mail.com", null, null, false, "a096ea62-efe9-4f00-92dd-6eb25e1086f6", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 3, "+359888888887", "f5563c5e-d780-4bce-812d-408f2c079ae2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5563c5e-d780-4bce-812d-408f2c079ae2");

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
    }
}
