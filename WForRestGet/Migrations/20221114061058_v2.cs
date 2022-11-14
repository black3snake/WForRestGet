using Microsoft.EntityFrameworkCore.Migrations;

namespace WForRestGet.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Datausers",
                nullable: true,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    AnswerType = table.Column<string>(maxLength: 4, nullable: false),
                    AnswerDescription = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerDescription", "AnswerType" },
                values: new object[,]
                {
                    { 1, "Автоответа в Exchange нет", "AN" },
                    { 2, "Excaption на установку ответа", "AA" },
                    { 3, "Автоответ установлен", "AG" },
                    { 4, "АВтоответ установлен пользователем", "AU" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Datausers_AnswerId",
                table: "Datausers",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Datausers_Answers_AnswerId",
                table: "Datausers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Datausers_Answers_AnswerId",
                table: "Datausers");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Datausers_AnswerId",
                table: "Datausers");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Datausers");
        }
    }
}
