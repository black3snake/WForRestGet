using Microsoft.EntityFrameworkCore.Migrations;

namespace WForRestGet.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1,
                column: "AnswerDescription",
                value: "Автоответа статус неизвестен");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1,
                column: "AnswerDescription",
                value: "Автоответа в Exchange нет");
        }
    }
}
