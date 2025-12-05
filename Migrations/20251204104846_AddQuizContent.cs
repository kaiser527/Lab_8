using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_8.Migrations
{
    public partial class AddQuizContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuizContents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Audio = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizContents_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizContents_QuizId",
                table: "QuizContents",
                column: "QuizId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizContents");
        }
    }
}
