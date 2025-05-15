using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDb_Gabriel_Viinikka.Migrations
{
    /// <inheritdoc />
    public partial class Refactor_Books_and_Authors_adding_Inventory_and_LoanCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbLoans_Books_BookId",
                table: "DbLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_DbLoans_Loaners_LoanerId",
                table: "DbLoans");

            migrationBuilder.DropColumn(
                name: "LoanedOn",
                table: "DbLoans");

            migrationBuilder.DropColumn(
                name: "ReturnDueOn",
                table: "DbLoans");

            migrationBuilder.DropColumn(
                name: "ReturnedOn",
                table: "DbLoans");

            migrationBuilder.DropColumn(
                name: "CopiesTotal",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LoanedTotal",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "LoanerId",
                table: "DbLoans",
                newName: "LoanCardId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "DbLoans",
                newName: "InventoryBookId");

            migrationBuilder.RenameIndex(
                name: "IX_DbLoans_LoanerId",
                table: "DbLoans",
                newName: "IX_DbLoans_LoanCardId");

            migrationBuilder.RenameIndex(
                name: "IX_DbLoans_BookId",
                table: "DbLoans",
                newName: "IX_DbLoans_InventoryBookId");

            migrationBuilder.RenameColumn(
                name: "BookTitle",
                table: "Books",
                newName: "Title");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualReturnDate",
                table: "DbLoans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedReturnDate",
                table: "DbLoans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LoanDate",
                table: "DbLoans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "InventoryBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanerId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanCards_Loaners_LoanerId",
                        column: x => x.LoanerId,
                        principalTable: "Loaners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryBooks_BookId",
                table: "InventoryBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanCards_LoanerId",
                table: "LoanCards",
                column: "LoanerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DbLoans_InventoryBooks_InventoryBookId",
                table: "DbLoans",
                column: "InventoryBookId",
                principalTable: "InventoryBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbLoans_LoanCards_LoanCardId",
                table: "DbLoans",
                column: "LoanCardId",
                principalTable: "LoanCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbLoans_InventoryBooks_InventoryBookId",
                table: "DbLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_DbLoans_LoanCards_LoanCardId",
                table: "DbLoans");

            migrationBuilder.DropTable(
                name: "InventoryBooks");

            migrationBuilder.DropTable(
                name: "LoanCards");

            migrationBuilder.DropColumn(
                name: "ActualReturnDate",
                table: "DbLoans");

            migrationBuilder.DropColumn(
                name: "ExpectedReturnDate",
                table: "DbLoans");

            migrationBuilder.DropColumn(
                name: "LoanDate",
                table: "DbLoans");

            migrationBuilder.RenameColumn(
                name: "LoanCardId",
                table: "DbLoans",
                newName: "LoanerId");

            migrationBuilder.RenameColumn(
                name: "InventoryBookId",
                table: "DbLoans",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_DbLoans_LoanCardId",
                table: "DbLoans",
                newName: "IX_DbLoans_LoanerId");

            migrationBuilder.RenameIndex(
                name: "IX_DbLoans_InventoryBookId",
                table: "DbLoans",
                newName: "IX_DbLoans_BookId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Books",
                newName: "BookTitle");

            migrationBuilder.AddColumn<DateOnly>(
                name: "LoanedOn",
                table: "DbLoans",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "ReturnDueOn",
                table: "DbLoans",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ReturnedOn",
                table: "DbLoans",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CopiesTotal",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoanedTotal",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DbLoans_Books_BookId",
                table: "DbLoans",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbLoans_Loaners_LoanerId",
                table: "DbLoans",
                column: "LoanerId",
                principalTable: "Loaners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
