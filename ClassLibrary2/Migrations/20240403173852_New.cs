using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingHouseSystem.Infrastructure.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_UserId",
                table: "Agents");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Houses",
                type: "nvarchar(450)",
                nullable: true,
                comment: "User id of the renterer",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "User id of the renterer");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a659012-94d8-4530-a102-5cfceb82aaf5", "AQAAAAEAACcQAAAAED+0EGVF8NEMWaOUieldzWER3QIjeq2dGSLrASYN0IrAPY6nunanOuHBl9qkg+5vaw==", "d070327c-212c-4189-8b66-cb697eb8b3ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3eaddd7-394e-4ef1-a8b2-5fd54482ef65", "AQAAAAEAACcQAAAAEAZLsqG7TqgXfWecSOWuFVOWJNSA8sFcOYmGlMXAq3p0Htgrv1p4wekXmJw+7A+MAQ==", "6fa16f1d-fbc3-4c11-86fd-2346b02ff1a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5563c5e-d780-4bce-812d-408f2c079ae2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d28e9fc-b239-445b-9084-d819839eaa7c", "AQAAAAEAACcQAAAAEOfPsDo+KWv+Y4nViOvIvL74zR+YycFQeY8tYAybSDd35bI9I0mjeH577MO7ubz6vg==", "f1bc9a4f-fa8d-49e0-9b08-ad696dbea921" });

            migrationBuilder.CreateIndex(
                name: "IX_Houses_RenterId",
                table: "Houses",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_AspNetUsers_RenterId",
                table: "Houses",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_AspNetUsers_RenterId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_RenterId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Agents_UserId",
                table: "Agents");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User id of the renterer",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldComment: "User id of the renterer");

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

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");
        }
    }
}
