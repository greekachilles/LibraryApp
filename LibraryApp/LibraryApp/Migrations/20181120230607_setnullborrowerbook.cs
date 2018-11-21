using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryApp.Migrations
{
    public partial class setnullborrowerbook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Borrower",
                table: "Book");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Borrower",
                table: "Book",
                column: "BorrowerId",
                principalTable: "Borrower",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Borrower",
                table: "Book");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Borrower",
                table: "Book",
                column: "BorrowerId",
                principalTable: "Borrower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
