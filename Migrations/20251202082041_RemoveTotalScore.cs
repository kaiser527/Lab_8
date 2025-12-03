using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_8.Migrations
{
    public partial class RemoveTotalScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalScore",
                table: "Histories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalScore",
                table: "Histories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
