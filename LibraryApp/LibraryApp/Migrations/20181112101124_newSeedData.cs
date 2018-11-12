using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryApp.Migrations
{
    public partial class newSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "BookId", "Author", "BorrowerId", "Name", "Year" },
                values: new object[,]
                {
                    { 4, "Melissa Meyers", null, "Radiant Shadows", 2012 },
                    { 5, "City of Sins", null, "Daniel Blake", 2008 },
                    { 6, "Patricia Cornwell", null, "Point of Origin", 2015 },
                    { 7, "Rachel Caine", null, "Chill Factor", 2007 }
                });

            migrationBuilder.InsertData(
                table: "Borrower",
                columns: new[] { "Id", "Age", "Name", "Phone" },
                values: new object[,]
                {
                    { 3, 19, "James Brooks", "123-456-789" },
                    { 4, 23, "Jeremy Michaels", "999-888-777" },
                    { 5, 19, "Jessica Dwyer", "455-566-677" },
                    { 6, 21, "Marcos Pauls", "122-333-444" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Borrower",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Borrower",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Borrower",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Borrower",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
