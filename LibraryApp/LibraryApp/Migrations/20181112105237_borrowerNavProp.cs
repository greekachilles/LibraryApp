using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryApp.Migrations
{
    public partial class borrowerNavProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bookNavBookId",
                table: "Borrower",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Borrower_bookNavBookId",
                table: "Borrower",
                column: "bookNavBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrower_Book_bookNavBookId",
                table: "Borrower",
                column: "bookNavBookId",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrower_Book_bookNavBookId",
                table: "Borrower");

            migrationBuilder.DropIndex(
                name: "IX_Borrower_bookNavBookId",
                table: "Borrower");

            migrationBuilder.DropColumn(
                name: "bookNavBookId",
                table: "Borrower");
        }
    }
}
