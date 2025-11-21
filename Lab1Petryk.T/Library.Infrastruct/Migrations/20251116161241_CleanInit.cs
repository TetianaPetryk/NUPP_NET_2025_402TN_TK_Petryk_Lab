using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastruct.Migrations
{
    /// <inheritdoc />
    public partial class CleanInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookModelId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_BookModelId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Reviews",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "BookModelId",
                table: "Reviews",
                newName: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Reviews",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookId",
                table: "Reviews",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Reviews",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Reviews",
                newName: "BookModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookModelId",
                table: "Reviews",
                column: "BookModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookModelId",
                table: "Reviews",
                column: "BookModelId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
