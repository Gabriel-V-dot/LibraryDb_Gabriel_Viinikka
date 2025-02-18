using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDb_Gabriel_Viinikka.Migrations
{
    /// <inheritdoc />
    public partial class revised_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbLoans_BooksInventory_ActualBookId",
                table: "DbLoans");

            migrationBuilder.DropTable(
                name: "BooksInventory");

            migrationBuilder.RenameColumn(
                name: "LoanerLastName",
                table: "Loaners",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "LoanerFirstName",
                table: "Loaners",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "DbLoans",
                newName: "ReturnedOn");

            migrationBuilder.RenameColumn(
                name: "LoanDate",
                table: "DbLoans",
                newName: "LoanedOn");

            migrationBuilder.RenameColumn(
                name: "ActualReturnDate",
                table: "DbLoans",
                newName: "ReturnDueOn");

            migrationBuilder.RenameColumn(
                name: "ActualBookId",
                table: "DbLoans",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_DbLoans_ActualBookId",
                table: "DbLoans",
                newName: "IX_DbLoans_BookId");

            migrationBuilder.RenameColumn(
                name: "AuthorLastName",
                table: "Authors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "AuthorFirstName",
                table: "Authors",
                newName: "FirstName");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Loaners",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbLoans_Books_BookId",
                table: "DbLoans");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Loaners");

            migrationBuilder.DropColumn(
                name: "CopiesTotal",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LoanedTotal",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Loaners",
                newName: "LoanerLastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Loaners",
                newName: "LoanerFirstName");

            migrationBuilder.RenameColumn(
                name: "ReturnedOn",
                table: "DbLoans",
                newName: "ReturnDate");

            migrationBuilder.RenameColumn(
                name: "ReturnDueOn",
                table: "DbLoans",
                newName: "ActualReturnDate");

            migrationBuilder.RenameColumn(
                name: "LoanedOn",
                table: "DbLoans",
                newName: "LoanDate");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "DbLoans",
                newName: "ActualBookId");

            migrationBuilder.RenameIndex(
                name: "IX_DbLoans_BookId",
                table: "DbLoans",
                newName: "IX_DbLoans_ActualBookId");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Authors",
                newName: "AuthorLastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Authors",
                newName: "AuthorFirstName");

            migrationBuilder.CreateTable(
                name: "BooksInventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksInventory_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BooksInventory_BookId",
                table: "BooksInventory",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbLoans_BooksInventory_ActualBookId",
                table: "DbLoans",
                column: "ActualBookId",
                principalTable: "BooksInventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
