using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDb_Gabriel_Viinikka.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Rating_Junction_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbLoans_InventoryBooks_InventoryBookId",
                table: "DbLoans");

            migrationBuilder.RenameColumn(
                name: "InventoryBookId",
                table: "DbLoans",
                newName: "InventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_DbLoans_InventoryBookId",
                table: "DbLoans",
                newName: "IX_DbLoans_InventoryId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Loaners",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Loaners",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_DbLoans_InventoryBooks_InventoryId",
                table: "DbLoans",
                column: "InventoryId",
                principalTable: "InventoryBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbLoans_InventoryBooks_InventoryId",
                table: "DbLoans");

            migrationBuilder.RenameColumn(
                name: "InventoryId",
                table: "DbLoans",
                newName: "InventoryBookId");

            migrationBuilder.RenameIndex(
                name: "IX_DbLoans_InventoryId",
                table: "DbLoans",
                newName: "IX_DbLoans_InventoryBookId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Loaners",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Loaners",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AddForeignKey(
                name: "FK_DbLoans_InventoryBooks_InventoryBookId",
                table: "DbLoans",
                column: "InventoryBookId",
                principalTable: "InventoryBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
