using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDb_Gabriel_Viinikka.Migrations
{
    /// <inheritdoc />
    public partial class Refactor_BooksRatings_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
