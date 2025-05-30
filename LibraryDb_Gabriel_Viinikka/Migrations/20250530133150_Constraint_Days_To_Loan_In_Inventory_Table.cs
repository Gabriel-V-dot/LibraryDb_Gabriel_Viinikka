using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDb_Gabriel_Viinikka.Migrations
{
    /// <inheritdoc />
    public partial class Constraint_Days_To_Loan_In_Inventory_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DaysToLoan",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Inventory_DaysToLoan",
                table: "Inventories",
                sql: "[DaysToLoan] BETWEEN 1 AND 60");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Inventory_DaysToLoan",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "DaysToLoan",
                table: "Inventories");
        }
    }
}
