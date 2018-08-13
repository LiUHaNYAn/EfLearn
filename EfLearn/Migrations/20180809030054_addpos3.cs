using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfLearn.Migrations
{
    public partial class addpos3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_blog_tb_blog_BlogId",
                table: "tb_blog");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "tb_blog",
                newName: "Parentid");

            migrationBuilder.RenameIndex(
                name: "IX_tb_blog_BlogId",
                table: "tb_blog",
                newName: "IX_tb_blog_Parentid");

            migrationBuilder.UpdateData(
                table: "tb_blog",
                keyColumn: "id",
                keyValue: 4,
                column: "CreateTime",
                value: new DateTime(2018, 8, 9, 11, 0, 53, 684, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_tb_blog_tb_blog_Parentid",
                table: "tb_blog",
                column: "Parentid",
                principalTable: "tb_blog",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_blog_tb_blog_Parentid",
                table: "tb_blog");

            migrationBuilder.RenameColumn(
                name: "Parentid",
                table: "tb_blog",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_blog_Parentid",
                table: "tb_blog",
                newName: "IX_tb_blog_BlogId");

            migrationBuilder.UpdateData(
                table: "tb_blog",
                keyColumn: "id",
                keyValue: 4,
                column: "CreateTime",
                value: new DateTime(2018, 8, 9, 10, 59, 38, 51, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_tb_blog_tb_blog_BlogId",
                table: "tb_blog",
                column: "BlogId",
                principalTable: "tb_blog",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
