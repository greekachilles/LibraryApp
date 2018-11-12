using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryApp.Migrations
{
    public partial class addData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "BookId", "Author", "BorrowerId", "Name", "Year" },
                values: new object[,]
                {
                    { 1, "Mary-Jane Smith", null, "My First Book", 2008 },
                    { 2, "Mary-Jane Smith", null, "A Science Book", 2010 },
                    { 3, "John Doe", null, "Classics Revisited", 2015 }
                });

            migrationBuilder.InsertData(
                table: "Borrower",
                columns: new[] { "Id", "Age", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, 15, "Kelly Potts", "222-333-444" },
                    { 2, 36, "Mike Smith", "444-555-666" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Borrower",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Borrower",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
