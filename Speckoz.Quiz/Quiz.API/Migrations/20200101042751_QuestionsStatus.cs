using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.API.Migrations
{
    public partial class QuestionsStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionsStatus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    QuestionStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsStatus", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionsStatus");
        }
    }
}
