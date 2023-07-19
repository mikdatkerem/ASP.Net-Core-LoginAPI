using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "password" },
                values: new object[] { 1,"miko", 159753 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "password" },
                values: new object[] { 2, "kero", 147852 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "password" },
                values: new object[] { 3, "miky", 369852 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
