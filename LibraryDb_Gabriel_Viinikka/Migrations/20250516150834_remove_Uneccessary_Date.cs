using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDb_Gabriel_Viinikka.Migrations
{
    /// <inheritdoc />
    public partial class remove_Uneccessary_Date : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualReturnDate",
                table: "DbLoans");

            migrationBuilder.RenameColumn(
                name: "ExpectedReturnDate",
                table: "DbLoans",
                newName: "ReturnDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "DbLoans",
                newName: "ExpectedReturnDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualReturnDate",
                table: "DbLoans",
                type: "datetime2",
                nullable: true);
        }
    }
}
