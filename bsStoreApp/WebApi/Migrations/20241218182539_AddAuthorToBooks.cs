using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddAuthorToBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a04f196-9c27-4c96-9df9-a82cda92b70a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae9a2774-7d0c-4d60-8195-71993fa3fe74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b33e5c41-1346-4f5e-b853-9b34782a1d4a");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e470261-d926-4007-9e36-0dc326edb386", "05a4eb9a-1204-466f-844f-b5931fc7b61d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "74417bd3-7a71-40e3-b152-06b73a703a95", "a932f940-8d55-4660-bd28-37369b85d032", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4d7b41c-a373-4e29-b937-c092bb7240ed", "25dc928c-6029-4396-8ec2-ef0fcc090a0c", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e470261-d926-4007-9e36-0dc326edb386");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74417bd3-7a71-40e3-b152-06b73a703a95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4d7b41c-a373-4e29-b937-c092bb7240ed");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9a04f196-9c27-4c96-9df9-a82cda92b70a", "ac998bdc-8681-4d3a-a2b8-a5a822edd47c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae9a2774-7d0c-4d60-8195-71993fa3fe74", "745d77fd-ce52-411c-a1ab-3d64140a0215", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b33e5c41-1346-4f5e-b853-9b34782a1d4a", "ffa88595-2311-40ea-997b-4b3b0a2cf44e", "Admin", "ADMIN" });
        }
    }
}
