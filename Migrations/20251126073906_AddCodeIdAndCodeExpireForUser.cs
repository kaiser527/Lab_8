using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_8.Migrations
{
    public partial class AddCodeIdAndCodeExpireForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CodeExpire",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CodeId",
                table: "Users",
                maxLength: 6,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeExpire",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CodeId",
                table: "Users");
        }
    }
}
