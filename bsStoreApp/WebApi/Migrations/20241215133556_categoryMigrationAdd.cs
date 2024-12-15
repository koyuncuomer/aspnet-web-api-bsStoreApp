using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class categoryMigrationAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ade6317-0796-4229-bb31-83156dfefea0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7ea1b25-9b4b-4f39-ad19-01bd49c483dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fef50b03-928c-495f-a186-ce2b13b73fcc");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "392446e4-2a59-4b36-ab94-9fc6ab9515e0", "7f8702d4-c457-4b9e-9949-20998b92d24a", "Editor", "EDITOR" },
                    { "a0ec74d6-b88a-4b62-8ce6-eab1aa47c28d", "4d32fa08-fbb5-4ed3-82d3-b08ab20c7ece", "User", "USER" },
                    { "dfc42d0f-2a20-4af4-8664-1a41db537251", "0ada82e3-02c6-4b21-ad23-3ef419f55a89", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Kategori 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "392446e4-2a59-4b36-ab94-9fc6ab9515e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0ec74d6-b88a-4b62-8ce6-eab1aa47c28d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfc42d0f-2a20-4af4-8664-1a41db537251");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ade6317-0796-4229-bb31-83156dfefea0", "e65da895-2f0b-4c37-8d42-d00c65752565", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7ea1b25-9b4b-4f39-ad19-01bd49c483dd", "7905b1f8-55d0-495b-adac-2386d0c33bb9", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fef50b03-928c-495f-a186-ce2b13b73fcc", "686233b8-5f37-4808-997c-375b992f4486", "Admin", "ADMIN" });
        }
    }
}
