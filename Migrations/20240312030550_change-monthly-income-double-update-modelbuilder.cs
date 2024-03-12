using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetPlanner.Migrations
{
    /// <inheritdoc />
    public partial class changemonthlyincomedoubleupdatemodelbuilder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetItems_Users_UserId",
                table: "BudgetItems");

            migrationBuilder.AlterColumn<double>(
                name: "MonthlyIncome",
                table: "Users",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetItems_Users_UserId",
                table: "BudgetItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetItems_Users_UserId",
                table: "BudgetItems");

            migrationBuilder.AlterColumn<int>(
                name: "MonthlyIncome",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetItems_Users_UserId",
                table: "BudgetItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
