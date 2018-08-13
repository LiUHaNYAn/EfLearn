using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfLearn.Migrations
{
    public partial class addpos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "tb_blog",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "tb_blog",
                keyColumn: "id",
                keyValue: 4,
                column: "CreateTime",
                value: new DateTime(2018, 8, 9, 10, 59, 38, 51, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_tb_blog_BlogId",
                table: "tb_blog",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_blog_tb_blog_BlogId",
                table: "tb_blog",
                column: "BlogId",
                principalTable: "tb_blog",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_blog_tb_blog_BlogId",
                table: "tb_blog");

            migrationBuilder.DropIndex(
                name: "IX_tb_blog_BlogId",
                table: "tb_blog");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "tb_blog");

            migrationBuilder.UpdateData(
                table: "tb_blog",
                keyColumn: "id",
                keyValue: 4,
                column: "CreateTime",
                value: new DateTime(2018, 8, 9, 10, 38, 4, 481, DateTimeKind.Local));
        }
    }
}
