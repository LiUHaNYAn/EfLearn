using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfLearn.Migrations
{
    public partial class add_title : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tb_blog",
                keyColumn: "id",
                keyValue: 4,
                column: "CreateTime",
                value: new DateTime(2018, 8, 9, 11, 11, 6, 202, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tb_blog",
                keyColumn: "id",
                keyValue: 4,
                column: "CreateTime",
                value: new DateTime(2018, 8, 9, 11, 0, 53, 684, DateTimeKind.Local));
        }
    }
}
