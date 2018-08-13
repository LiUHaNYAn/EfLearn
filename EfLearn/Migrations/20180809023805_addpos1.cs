using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfLearn.Migrations
{
    public partial class addpos1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tb_blog",
                columns: new[] { "id", "content", "CreateTime", "title" },
                values: new object[] { 4, "seeding data", new DateTime(2018, 8, 9, 10, 38, 4, 481, DateTimeKind.Local), "seeding demo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_blog",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
