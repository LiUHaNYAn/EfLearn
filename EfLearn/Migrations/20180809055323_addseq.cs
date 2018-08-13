using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfLearn.Migrations
{
    public partial class addseq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "orderid",
                startValue: 100000L);

            migrationBuilder.AddColumn<Guid>(
                name: "Token",
                table: "UserInfos",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR orderid");

            migrationBuilder.UpdateData(
                table: "tb_blog",
                keyColumn: "id",
                keyValue: 4,
                column: "CreateTime",
                value: new DateTime(2018, 8, 9, 13, 53, 22, 723, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "orderid");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "UserInfos");

            migrationBuilder.UpdateData(
                table: "tb_blog",
                keyColumn: "id",
                keyValue: 4,
                column: "CreateTime",
                value: new DateTime(2018, 8, 9, 13, 45, 22, 839, DateTimeKind.Local));
        }
    }
}
