using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfLearn.Migrations
{
    public partial class addpost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "tb_blog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_blog",
                table: "tb_blog",
                column: "id");

            migrationBuilder.CreateTable(
                name: "tb_post",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 50, nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogId = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_post", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_post_tb_blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "tb_blog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_post_BlogId",
                table: "tb_post",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_blog",
                table: "tb_blog");

            migrationBuilder.RenameTable(
                name: "tb_blog",
                newName: "Blogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "id");
        }
    }
}
