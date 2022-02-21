using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class UpdateColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Book",
                newName: "IdBook");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Author_Book",
                newName: "IdBook");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Author_Book",
                newName: "IdAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_Author_Book_BookId",
                table: "Author_Book",
                newName: "IX_Author_Book_IdBook");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Author",
                newName: "IdAuthor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdBook",
                table: "Book",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdBook",
                table: "Author_Book",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "IdAuthor",
                table: "Author_Book",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Author_Book_IdBook",
                table: "Author_Book",
                newName: "IX_Author_Book_BookId");

            migrationBuilder.RenameColumn(
                name: "IdAuthor",
                table: "Author",
                newName: "Id");
        }
    }
}
