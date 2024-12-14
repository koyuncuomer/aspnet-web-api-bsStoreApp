using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddRolesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "13e3ae2d-8d74-46fa-99d5-f54620f0d949", "7b2b086c-ffee-4c5b-85c0-d95f14b32b58", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "77b7bd34-48c3-402e-80a5-3db00d7f517a", "c6b9b961-21fd-4774-93b2-52c56c6c17e0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9135401a-f830-4e6a-a9ce-94d1b32056d3", "30500952-4576-414b-a91f-ca8533e29e5f", "Editor", "EDITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13e3ae2d-8d74-46fa-99d5-f54620f0d949");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77b7bd34-48c3-402e-80a5-3db00d7f517a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9135401a-f830-4e6a-a9ce-94d1b32056d3");
        }
    }
}
