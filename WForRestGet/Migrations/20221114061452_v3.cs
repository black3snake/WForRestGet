using Microsoft.EntityFrameworkCore.Migrations;

namespace WForRestGet.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2,
                column: "AnswerDescription",
                value: "Exception на установку ответа");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4,
                column: "AnswerDescription",
                value: "Автоответ установлен пользователем");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2,
                column: "AnswerDescription",
                value: "Excaption на установку ответа");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4,
                column: "AnswerDescription",
                value: "АВтоответ установлен пользователем");
        }
    }
}
