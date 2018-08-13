using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfLearn.Migrations
{
    public partial class adduserinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "tb_blog",
                keyColumn: "id",
                keyValue: 4,
                column: "CreateTime",
                value: new DateTime(2018, 8, 9, 13, 45, 22, 839, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.UpdateData(
                table: "tb_blog",
                keyColumn: "id",
                keyValue: 4,
                column: "CreateTime",
                value: new DateTime(2018, 8, 9, 11, 11, 6, 202, DateTimeKind.Local));
        }
    }
}
