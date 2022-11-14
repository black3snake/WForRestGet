using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WForRestGet.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LeaveType = table.Column<string>(maxLength: 4, nullable: false),
                    LeaveDescription = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Datausers",
                columns: table => new
                {
                    FimSyncKey = table.Column<string>(maxLength: 40, nullable: false),
                    AccountId = table.Column<string>(maxLength: 50, nullable: false),
                    AccountName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    EmployeeNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true),
                    CompanyName = table.Column<string>(maxLength: 300, nullable: true),
                    DepartmentName = table.Column<string>(maxLength: 200, nullable: true),
                    JobTitle = table.Column<string>(maxLength: 200, nullable: true),
                    DateIn = table.Column<DateTime>(type: "date", nullable: true),
                    LeaveId = table.Column<int>(nullable: true, defaultValue: 0),
                    LeaveStart = table.Column<DateTime>(type: "date", nullable: true),
                    LeaveEnd = table.Column<DateTime>(type: "date", nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datausers", x => x.FimSyncKey);
                    table.ForeignKey(
                        name: "FK_Datausers_Leaves_LeaveId",
                        column: x => x.LeaveId,
                        principalTable: "Leaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Leaves",
                columns: new[] { "Id", "LeaveDescription", "LeaveType" },
                values: new object[,]
                {
                    { 1, "отпуск", "VC" },
                    { 2, "больничный", "SL" },
                    { 3, "командировка", "BT" },
                    { 4, "декретный отпуск", "DV" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Datausers_LeaveId",
                table: "Datausers",
                column: "LeaveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datausers");

            migrationBuilder.DropTable(
                name: "Leaves");
        }
    }
}
