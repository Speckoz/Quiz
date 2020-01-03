using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.API.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(nullable: false),
                    CorrectAnswer = table.Column<string>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    IncorrectAnswers = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionID);
                });

            migrationBuilder.CreateTable(
                name: "QuestionsStatus",
                columns: table => new
                {
                    QuestionID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(nullable: false),
                    QuestionStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsStatus", x => x.QuestionID);
                });

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    QuestionSuggestionID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(nullable: false),
                    CorrectAnswer = table.Column<string>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    IncorrectAnswers = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.QuestionSuggestionID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "QuestionsStatus");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
