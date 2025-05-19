using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDb_Gabriel_Viinikka.Migrations
{
    /// <inheritdoc />
    public partial class Refactor_loaners_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRating_Rating_RatingsId",
                table: "BookRating");

            migrationBuilder.DropForeignKey(
                name: "FK_DbLoans_InventoryBooks_InventoryId",
                table: "DbLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryBooks_Books_BookId",
                table: "InventoryBooks");

            migrationBuilder.DropIndex(
                name: "IX_LoanCards_LoanerId",
                table: "LoanCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryBooks",
                table: "InventoryBooks");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameTable(
                name: "InventoryBooks",
                newName: "Inventory");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryBooks_BookId",
                table: "Inventory",
                newName: "IX_Inventory_BookId");

            migrationBuilder.AlterColumn<string>(
                name: "CardId",
                table: "Loaners",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LoanCards_LoanerId",
                table: "LoanCards",
                column: "LoanerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRating_Ratings_RatingsId",
                table: "BookRating",
                column: "RatingsId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbLoans_Inventory_InventoryId",
                table: "DbLoans",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Books_BookId",
                table: "Inventory",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRating_Ratings_RatingsId",
                table: "BookRating");

            migrationBuilder.DropForeignKey(
                name: "FK_DbLoans_Inventory_InventoryId",
                table: "DbLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Books_BookId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_LoanCards_LoanerId",
                table: "LoanCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameTable(
                name: "Inventory",
                newName: "InventoryBooks");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_BookId",
                table: "InventoryBooks",
                newName: "IX_InventoryBooks_BookId");

            migrationBuilder.AlterColumn<int>(
                name: "CardId",
                table: "Loaners",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryBooks",
                table: "InventoryBooks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LoanCards_LoanerId",
                table: "LoanCards",
                column: "LoanerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookRating_Rating_RatingsId",
                table: "BookRating",
                column: "RatingsId",
                principalTable: "Rating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbLoans_InventoryBooks_InventoryId",
                table: "DbLoans",
                column: "InventoryId",
                principalTable: "InventoryBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryBooks_Books_BookId",
                table: "InventoryBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
