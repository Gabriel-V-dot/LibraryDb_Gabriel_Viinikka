using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDb_Gabriel_Viinikka.Migrations
{
    /// <inheritdoc />
    public partial class Loaner_Cascade_Delete_to_Null_on_loanCard_loans_not_nullable_loanCard_and_Inventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbLoans_Inventory_InventoryId",
                table: "DbLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_DbLoans_LoanCards_LoanCardId",
                table: "DbLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanCards_Loaners_LoanerId",
                table: "LoanCards");

            migrationBuilder.AlterColumn<int>(
                name: "LoanCardId",
                table: "DbLoans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryId",
                table: "DbLoans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DbLoans_Inventory_InventoryId",
                table: "DbLoans",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbLoans_LoanCards_LoanCardId",
                table: "DbLoans",
                column: "LoanCardId",
                principalTable: "LoanCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanCards_Loaners_LoanerId",
                table: "LoanCards",
                column: "LoanerId",
                principalTable: "Loaners",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbLoans_Inventory_InventoryId",
                table: "DbLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_DbLoans_LoanCards_LoanCardId",
                table: "DbLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanCards_Loaners_LoanerId",
                table: "LoanCards");

            migrationBuilder.AlterColumn<int>(
                name: "LoanCardId",
                table: "DbLoans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryId",
                table: "DbLoans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DbLoans_Inventory_InventoryId",
                table: "DbLoans",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DbLoans_LoanCards_LoanCardId",
                table: "DbLoans",
                column: "LoanCardId",
                principalTable: "LoanCards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanCards_Loaners_LoanerId",
                table: "LoanCards",
                column: "LoanerId",
                principalTable: "Loaners",
                principalColumn: "Id");
        }
    }
}
