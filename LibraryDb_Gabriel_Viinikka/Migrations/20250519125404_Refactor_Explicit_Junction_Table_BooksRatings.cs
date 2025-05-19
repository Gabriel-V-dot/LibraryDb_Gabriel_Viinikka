using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDb_Gabriel_Viinikka.Migrations
{
    /// <inheritdoc />
    public partial class Refactor_Explicit_Junction_Table_BooksRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Rating_RatingId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_RatingId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Rating",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "BookRating",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    RatingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRating", x => new { x.BooksId, x.RatingsId });
                    table.ForeignKey(
                        name: "FK_BookRating_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookRating_Rating_RatingsId",
                        column: x => x.RatingsId,
                        principalTable: "Rating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRating_RatingsId",
                table: "BookRating",
                column: "RatingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRating");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Rating",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_RatingId",
                table: "Books",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Rating_RatingId",
                table: "Books",
                column: "RatingId",
                principalTable: "Rating",
                principalColumn: "Id");
        }
    }
}
