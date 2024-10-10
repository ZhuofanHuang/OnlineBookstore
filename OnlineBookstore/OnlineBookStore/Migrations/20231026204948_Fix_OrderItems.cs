using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBookStore.Migrations
{
    /// <inheritdoc />
    public partial class Fix_OrderItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OderItems_Books_BookId",
                table: "OderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OderItems_Orders_OrderId",
                table: "OderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OderItems",
                table: "OderItems");

            migrationBuilder.RenameTable(
                name: "OderItems",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OderItems_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OderItems_BookId",
                table: "OrderItems",
                newName: "IX_OrderItems_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Books_BookId",
                table: "OrderItems",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Books_BookId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "OderItems",
                newName: "IX_OderItems_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_BookId",
                table: "OderItems",
                newName: "IX_OderItems_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OderItems",
                table: "OderItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OderItems_Books_BookId",
                table: "OderItems",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OderItems_Orders_OrderId",
                table: "OderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
